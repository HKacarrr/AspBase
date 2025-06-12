using System.Linq.Expressions;

namespace Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> FindAllAsync();
    
    Task<T?> FindAsync(int id);
    
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    
    Task<T?> FindOneByAsync(Expression<Func<T, bool>> predicate);
    
    Task AddAsync(T entity);
    
    void Update(T entity);
    
    void Delete(T entity);
    
    Task<bool> SaveAsync();
}