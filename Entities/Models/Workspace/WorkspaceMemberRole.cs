using Entities.Models.Workspace.Providers;

namespace Entities.Models.Workspace;

public class WorkspaceMemberRole : WorkspaceProvider
{
    public string? Title { get; set; }
    
    public string? Alias { get; set; }
    
    public int? Degree  { get; set; }
    
    /** Relations */
    public ICollection<Workspace>? Workspaces { get; set; }
}