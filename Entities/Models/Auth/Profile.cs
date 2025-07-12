using Entities.Common;

namespace Entities.Models.Auth;

public class Profile : DatetimeProvider
{
    public string? Name { get; set; }
    
    public string? Surname { get; set; }
    
    public string? FullName { get; set; }
    
    public string? UserId { get; set; }
    
    public User? User { get; set; }
}