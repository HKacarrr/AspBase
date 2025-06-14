using Repositories.Product;

namespace Services.Product;
using Entities.Product;

public class ProductService : AbstractService<Product>
{
    public ProductService(ProductRepository repository) : base(repository)
    {
    }

    public async Task<List<Product>> ProductList()
    {
        return await Repository.FindAllAsync();
    }

    // public async Task<Product> CreateProduct()
    // {
    //     
    // }
}