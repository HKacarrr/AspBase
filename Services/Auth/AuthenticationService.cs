using AutoMapper;
using Entities.DTO.Auth;
using Entities.DTO.Auth.Profile;
using Entities.DTO.Auth.User;
using Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Repositories;
using Services.Auth.Profile;

namespace Services.Auth;

public class AuthenticationService : AbstractService<User>
{
    private readonly UserManager<User> _userManager;
    private readonly ProfileService _profileService;
    
    public AuthenticationService(IBaseRepository<User> repository, IMapper mapper, UserManager<User> userManager, ProfileService profileService) : base(repository, mapper)
    {
        _userManager = userManager;
        _profileService = profileService;
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
}