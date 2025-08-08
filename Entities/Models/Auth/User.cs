using Entities.Models.Workspace;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models.Auth;

public class User : IdentityUser
{
    public Profile? Profile { get; set; }
    
    public string? RefreshToken { get; set; }
    
    public DateTime RefreshTokenExpiryTime { get; set; }
    
    
    /** Relations */
    public ICollection<Workspace.Workspace>? Workspaces { get; set; } // User of the creating to workspace
    
    public ICollection<WorkspaceInvite>? WorkspaceInvites { get; set; } // Workspace Invites
    
    public ICollection<WorkspaceMember>? WorkspaceMembers { get; set; } // Workspace Members
    
    public ICollection<Team.Team>? Teams { get; set; }
    
    public ICollection<Team.TeamInvite>? TeamInvites { get; set; }
    
    public ICollection<Team.TeamMember>? TeamMembers { get; set; }
}