using Entities.Models.Auth;
using Entities.Models.Team.Providers;

namespace Entities.Models.Team;

public class TeamInvite : TeamAndTeamRoleProvider
{
    public bool? Active { get; set; }
    
    /** Relations */
    public string? UserId { get; set; }
    
    public User? User { get; set; }
}