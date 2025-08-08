using Entities.Models.Auth;
using Entities.Models.Workspace.Providers;

namespace Entities.Models.Team;

public class Team : WorkspaceProvider
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Logo { get; set; }
    
    public string? Uuid { get; set; }
    
    /** Relations */
    public string? UserId { get; set; }
    
    public User? CreatedUser { get; set; }
    
    public ICollection<TeamRole>? TeamRoles { get; set; }
    
    public ICollection<TeamInvite>? TeamInvites { get; set; }
    
    public ICollection<TeamMember>? TeamMembers { get; set; }
}