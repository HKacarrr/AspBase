using Entities.DTO.Auth;
using Entities.DTO.Auth.User;
using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Auth;


[ApiController]
public class AuthController : AbstractAuthController
{
    private readonly ServiceManager _serviceManager;
    
    public AuthController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }


    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Create(AuthDto authDto)
    {
        var userDto = await _serviceManager.AuthenticationService.RegisterUser(authDto);
        return Ok(userDto);
    }
}