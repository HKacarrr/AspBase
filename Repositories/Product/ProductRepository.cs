using Repositories.Config.Context;

namespace Repositories.Product;
using Entities.Product;

public sealed class ProductRepository : AbstractRepository<Product>
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }
}