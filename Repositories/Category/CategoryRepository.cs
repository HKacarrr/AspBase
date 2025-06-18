namespace Repositories.Category;

using Repositories.Config.Context;
using Entities.Category;

public sealed class CategoryRepository : AbstractRepository<Category>
{
    public CategoryRepository(RepositoryContext context) : base(context)
    {
    }
}