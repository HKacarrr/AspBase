using Repositories.Config.Context;

namespace Repositories.Models.Category;

public sealed class CategoryRepository : AbstractRepository<Entities.Models.Category.Category>
{
    public CategoryRepository(RepositoryContext context) : base(context)
    {
    }
}