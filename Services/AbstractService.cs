using Repositories;

namespace Services;

public abstract class AbstractService<T> where T : class
{
    protected readonly IBaseRepository<T> Repository;

    protected AbstractService(IBaseRepository<T> repository)
    {
        Repository = repository;
    }
}