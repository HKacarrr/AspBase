namespace Entities.DTO.Auth.Profile;

public record ProfileDto : AbstractDto
{
    public string? FirstName { get; init; }
    
    public string? LastName { get; init; }
}