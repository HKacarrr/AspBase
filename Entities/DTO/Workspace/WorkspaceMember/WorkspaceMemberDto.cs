namespace Entities.DTO.Workspace.WorkspaceMember;

public record WorkspaceMemberDto : AbstractDto
{
    public bool? Active { get; init; }

    public string? UserId { get; init; }
}