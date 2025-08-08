using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Auth.User;

public record UserDto : AbstractDto
{
    public string? Username { get; init; }
    
    [EmailAddress(ErrorMessage = "E-Mail is not valid!")]
    public string? EMail { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).+$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one special character")]
    public string? Password { get; init; }
    
    public ICollection<string>? Roles { get; init; }
}