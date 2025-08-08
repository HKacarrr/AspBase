using Entities.Common;

namespace Entities.Models.Team.Providers;

public class TeamProvider : DatetimeProvider
{
    public Guid TeamId { get; set; }
    
    public Team? Team { get; set; }
}