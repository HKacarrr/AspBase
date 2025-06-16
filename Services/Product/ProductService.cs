using Repositories.Product;

namespace Services.Product;
using Entities.Product;

public class ProductService : AbstractService<Product>
{
    /** Constructor */
    public ProductService(ProductRepository repository) : base(repository)
    {
    }

    
    /** Repositories */
    public ProductRepository ProductRepository => (ProductRepository)Repository;

    
    /** Functions */
    public async Task<List<Product>> ProductList()
    {
        return await Repository.FindAllAsync();
    }

    // public async Task<Product> CreateProduct()
    // {
    //     
    // }
}