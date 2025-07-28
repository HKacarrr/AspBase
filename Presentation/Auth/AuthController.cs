using Entities.DTO.Auth;
using Entities.DTO.Auth.User;
using Entities.DTO.Security;
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
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!await _serviceManager.AuthenticationService.Login(loginDto))
            return Unauthorized();
        
        var tokenDto = await _serviceManager.AuthenticationService.CreateToken(true);
        return Ok(tokenDto);
    }

    
    [HttpPost]
    [Route("refresh-token")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RefreshToken([FromBody]TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);
        return Ok(tokenDtoToReturn);
    }
}