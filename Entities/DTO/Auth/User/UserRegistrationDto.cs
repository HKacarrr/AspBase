using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Auth.User;

public record UserRegistrationDto
{
    [Required(ErrorMessage = "Username is required")]
    public string? Username { get; init; }
    
    [Required(ErrorMessage = "E-Mail is required")]
    [EmailAddress(ErrorMessage = "E-Mail address is not valid")]
    public string? EMail { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    
}