using AutoMapper;
using Repositories;

namespace Services.Workspace;

public abstract class AbstractWorkspaceService<TEntity>  : AbstractService<TEntity> where TEntity : class
{
    protected AbstractWorkspaceService(IBaseRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}