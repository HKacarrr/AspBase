using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Entities.DTO.Auth;
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


    public async Task<string> CreateToken()
    {
        var signInCredentials = GetSignInCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signInCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
}