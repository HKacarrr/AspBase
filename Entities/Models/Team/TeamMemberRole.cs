using Entities.Models.Team.Providers;

namespace Entities.Models.Team;

public class TeamMemberRole : TeamProvider
{
    public string? Title { get; set; }
    
    public string? Alias { get; set; }
    
    public string? Degree { get; set; }
    
    /** Relations */ 
    public ICollection<TeamInvite>? TeamInvites { get; set; }
    
    public ICollection<TeamMember>? TeamMembers { get; set; }
}