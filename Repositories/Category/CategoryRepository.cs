using Repositories.Config.Context;

namespace Repositories.Category;

public class CategoryRepository : AbstractRepository<Entities.Category.Category>
{
    public CategoryRepository(RepositoryContext context) : base(context)
    {
    }
}