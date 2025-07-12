using System.Text.Json.Serialization;
using Entities.DTO.Auth.Profile;
using Entities.DTO.Auth.User;

namespace Entities.DTO.Auth;

public record AuthDto
{
    [JsonPropertyName("user")]
    public UserRegistrationDto UserRegistrationDto { get; init; }
    
    [JsonPropertyName("profile")]
    public ProfileRegistrationDto ProfileRegistrationDto { get; init; }
}