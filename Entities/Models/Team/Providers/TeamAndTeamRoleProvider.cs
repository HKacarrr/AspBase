namespace Entities.Models.Team.Providers;

public class TeamAndTeamRoleProvider : TeamProvider
{
    public Guid TeamRoleId { get; set; }
    
    public TeamRole? TeamRole { get; set; }
}