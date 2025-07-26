using Entities.DTO.Auth;
using Entities.DTO.Auth.User;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters.Validation;
using Services.Config;

namespace Presentation.Auth;


[ApiController]
[ServiceFilter(typeof(ValidationFilterAttribute))]
public class AuthController : AbstractAuthController
{
    private readonly ServiceManager _serviceManager;
    
    public AuthController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }


    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(AuthDto authDto)
    {
        var userDto = await _serviceManager.AuthenticationService.RegisterUser(authDto);
        return Ok(userDto);
    }


    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }
}