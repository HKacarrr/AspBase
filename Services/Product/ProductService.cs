using AutoMapper;
using Entities.DTO.Product;
using Repositories.Product;

namespace Services.Product;
using Entities.Product;

public class ProductService : AbstractService<Product>
{
    /** Constructor */
    public ProductService(ProductRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    
    /** Repositories */
    public ProductRepository ProductRepository => (ProductRepository)Repository;

    
    /** Functions */
    public async Task<IEnumerable<ProductDto>> ProductList()
    {
        var products = await Repository.FindAllAsync();
        return Mapper.Map<IEnumerable<ProductDto>>(products);
    }

    // public async Task<Product> CreateProduct()
    // {
    //     
    // }
}