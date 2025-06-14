using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Config.Context;

namespace Repositories;

public abstract class AbstractRepository<T>  : IBaseRepository<T> where T : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> DbSet;

    public AbstractRepository(RepositoryContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }
    
    public virtual async Task<List<T>> FindAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<T?> FindAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return DbSet.Where(predicate);
    }

    public virtual async Task<T?> FindOneByAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public virtual async Task<bool> SaveAsync()
    {
        return await Context.SaveChangesAsync() > 0;
    }
}