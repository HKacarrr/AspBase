using System.ComponentModel.DataAnnotations;
using Entities.Models.Auth;

namespace Entities.DTO.Workspace.WorkspaceInvite;

public record WorkspaceInviteDto : AbstractDto
{
    [EmailAddress(ErrorMessage = "E-Mail is not valid!")]
    public string? Email { get; init; }
    
    public string? Phone { get; init; }
    
    public string? Status { get; init; }
    
    public string? Description { get; init; }
    
    public string? Uuid { get; init; }
    
    public User? User { get; init; }
    
}