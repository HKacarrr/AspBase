using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Auth;

public record LoginDto
{
    [Required(ErrorMessage = "E-Mail is required")]
    [EmailAddress(ErrorMessage = "E-Mail is not valid")]
    public string? Email { get; init; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
}