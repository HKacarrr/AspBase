using Microsoft.AspNetCore.Identity;

namespace Entities.Models.Auth;

public class User : IdentityUser
{
    public Profile? Profile { get; set; }
    
    public string? RefreshToken { get; set; }
    
    public DateTime RefreshTokenExpiryTime { get; set; }
}