namespace Entities.Models.Workspace.Providers;

public class WorkspaceAndWorkspaceMemberRoleProvider : WorkspaceProvider
{
    public Guid WorkspaceMemberRoleId { get; set; }
    
    public WorkspaceMemberRole? WorkspaceMemberRole { get; set; }
}