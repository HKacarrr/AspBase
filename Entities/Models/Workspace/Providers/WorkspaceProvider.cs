using Entities.Common;

namespace Entities.Models.Workspace.Providers;

public class WorkspaceProvider : DatetimeProvider
{   
    public Guid WorkspaceId { get; set; }
    
    public Workspace? Workspace { get; set; }
}