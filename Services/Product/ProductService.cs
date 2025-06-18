using AutoMapper;
using Entities.DTO.Product;
using Entities.Exceptions;
using Repositories.Product;

namespace Services.Product;
using Entities.Product;

public class ProductService : AbstractService<Product>
{
    /** Constructor */
    public ProductService(ProductRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    
    /** Functions */
    public async Task<IEnumerable<ProductDto>> ProductList()
    {
        var products = await Repository.FindAllAsync();
        return Mapper.Map<IEnumerable<ProductDto>>(products);
    }
    

    public async Task<CreateProductDto> CreateProduct(CreateProductDto createProductDto)
    {
        var product = Mapper.Map<Product>(createProductDto);
        await Repository.AddAsync(product);
        Repository.SaveAsync();

        return Mapper.Map<CreateProductDto>(product);
    }
    

    public async Task<ProductDto> GetProductById(Guid id)
    {
        var product = await CheckProduct(id);
        return Mapper.Map<ProductDto>(product);
    }


    public async Task UpdateProduct(Guid id, ProductDto productDto)
    {
        var updatingProduct = await CheckProduct(id);
        Mapper.Map(productDto, updatingProduct);
        Repository.Update(updatingProduct);
        Repository.SaveAsync();
    }


    public async Task DeleteProduct(Guid id)
    {
        var deletingProduct = await CheckProduct(id);
        Repository.Delete(deletingProduct);
        Repository.SaveAsync();
    }


    private async Task<Product> CheckProduct(Guid id)
    {
        var product = await Repository.FindOneByAsync(p => p.Id.Equals(id));
        if (product is null)
            throw new Exception("Product is not found!");

        return product;
    }
}