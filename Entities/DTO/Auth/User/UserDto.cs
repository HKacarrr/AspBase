namespace Entities.DTO.Auth.User;

public record UserDto : AbstractDto
{
    public string? Username { get; init; }
    
    public string? EMail { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    public string? Password { get; init; }
    
    public ICollection<string>? Roles { get; init; }
}