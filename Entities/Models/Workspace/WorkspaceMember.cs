using Entities.Models.Auth;
using Entities.Models.Workspace.Providers;

namespace Entities.Models.Workspace;

public class WorkspaceMember : WorkspaceAndWorkspaceMemberRoleProvider
{
    public bool? Active { get; set; }

    /** Relations */
    public string? UserId { get; set; }
    
    public User? User { get; set; }
    
    public ICollection<Workspace>? Workspaces { get; set; }
    
    public ICollection<WorkspaceMemberRole>? WorkspaceMemberRoles { get; set; }
}