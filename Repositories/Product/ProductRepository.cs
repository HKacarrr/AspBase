using Microsoft.EntityFrameworkCore;

namespace Repositories.Product;
using Entities.Product;

public class ProductRepository : AbstractRepository<Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}