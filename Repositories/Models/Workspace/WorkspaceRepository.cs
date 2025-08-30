using Repositories.Config.Context;

namespace Repositories.Models.Workspace;

public sealed class WorkspaceRepository : AbstractRepository<Entities.Models.Workspace.Workspace>
{
    public WorkspaceRepository(RepositoryContext context) : base(context)
    {
    }
}