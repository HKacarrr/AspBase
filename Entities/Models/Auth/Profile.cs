using Entities.Models.Auth.Providers;

namespace Entities.Models.Auth;

public class Profile : UserProvider
{
    public string? Name { get; set; }
    
    public string? Surname { get; set; }
    
    public string? FullName { get; set; }
}