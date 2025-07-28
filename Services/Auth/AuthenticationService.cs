using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Entities.DTO.Auth;
using Entities.DTO.Security;
using Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Services.Auth.Profile;

namespace Services.Auth;

public class AuthenticationService : AbstractService<User>
{
    private readonly UserManager<User> _userManager;
    private readonly ProfileService _profileService;
    private readonly IConfiguration _configuration;
    private User _user;
    
    public AuthenticationService(IBaseRepository<User> repository, IMapper mapper, UserManager<User> userManager, ProfileService profileService, IConfiguration configuration) : base(repository, mapper)
    {
        _userManager = userManager;
        _profileService = profileService;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUser(AuthDto authDto)
    {
        var user = Mapper.Map<User>(authDto.UserRegistrationDto);
        var result = await _userManager.CreateAsync(user, authDto.UserRegistrationDto.Password);

        if (result.Succeeded)
        {
            await _profileService.Create(authDto.ProfileRegistrationDto, user);
            await _userManager.AddToRolesAsync(user, ["USER"]);
        }
            

        return result;
    }


    public async Task<bool> Login(LoginDto loginDto)
    {
        _user = await _userManager.FindByEmailAsync(loginDto.Email);
        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password));

        if (!result)
            throw new Exception("Authentication failed!");

        return result;
    }


    public async Task<TokenDto> CreateToken(bool populateExp)
    {
        var signInCredentials = GetSignInCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signInCredentials, claims);

        var refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;

        if (populateExp)
            _user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1);

        await _userManager.UpdateAsync(_user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new TokenDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }


    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        var user = await _userManager.FindByNameAsync(principal.Identity.Name);

        if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            throw new Exception("Refresh token bas request");

        _user = user;
        return await CreateToken(false);
    }
    
    
    private SigningCredentials GetSignInCredentials()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }
    
    
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }


    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[128];
        
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }


    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["secretKey"];

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["validIssuer"],
            ValidAudience = jwtSettings["validAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException();
        
        return principal;
    }
}