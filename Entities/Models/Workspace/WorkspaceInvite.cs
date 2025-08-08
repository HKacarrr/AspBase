using Entities.Models.Auth;
using Entities.Models.Workspace.Providers;

namespace Entities.Models.Workspace;

public class WorkspaceInvite : WorkspaceAndWorkspaceMemberRoleProvider
{
    public string? Email { get; set; }
    
    public string? Phone { get; set; }
    
    public string? Status { get; set; }
    
    public string? Description { get; set; }
    
    public string? Uuid { get; set; }
    
    
    /** Relations */
    public string? UserId { get; set; }
    
    public User? User { get; set; }
    
    public ICollection<Workspace>? Workspaces { get; set; }
}