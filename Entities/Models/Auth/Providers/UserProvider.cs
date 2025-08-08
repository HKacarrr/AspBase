using Entities.Common;

namespace Entities.Models.Auth.Providers;

public class UserProvider : DatetimeProvider
{
    public string? UserId { get; set; }
    
    public User? User { get; set; }
}