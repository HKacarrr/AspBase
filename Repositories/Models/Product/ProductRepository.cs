using Repositories.Config.Context;

namespace Repositories.Models.Product;

public sealed class ProductRepository : AbstractRepository<Entities.Models.Product.Product>
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }
}