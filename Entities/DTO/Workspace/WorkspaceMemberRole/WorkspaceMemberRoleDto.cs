namespace Entities.DTO.Workspace.WorkspaceMemberRole;

public record WorkspaceMemberRoleDto : AbstractDto
{
    public string? Title { get; init; }
    
    public string? Alias { get; init; }
    
    public int? Degree  { get; init; }
}