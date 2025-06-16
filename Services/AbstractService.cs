using Repositories;
using AutoMapper;

namespace Services;

public abstract class AbstractService<T> where T : class
{
    protected readonly IBaseRepository<T> Repository;
    protected readonly IMapper Mapper;

    protected AbstractService(IBaseRepository<T> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }
}