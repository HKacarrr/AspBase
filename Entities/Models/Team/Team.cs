using Entities.Models.Auth;
using Entities.Models.Workspace.Providers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Team;

public class Team : WorkspaceProvider
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Logo { get; set; }
    
    public string? Uuid { get; set; }

    /** Relations */
    [ForeignKey(nameof(CreatedUser))]
    public string? CreatedUserId { get; set; }   // <-- "UserId" yerine navigation ile eş ad

    public User? CreatedUser { get; set; }

    public ICollection<TeamMemberRole>? TeamRoles { get; set; }
    
    public ICollection<TeamInvite>? TeamInvites { get; set; }
    
    public ICollection<TeamMember>? TeamMembers { get; set; }
}