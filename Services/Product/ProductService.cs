using AutoMapper;
using Entities.DTO.Product;
using Entities.Exceptions;
using Repositories.Models.Category;
using Repositories.Models.Product;

namespace Services.Product;

public class ProductService : AbstractService<Entities.Models.Product.Product>
{
    private readonly CategoryRepository _categoryRepository;
    
    /** Constructor */
    public ProductService(ProductRepository repository, IMapper mapper, CategoryRepository categoryRepository) : base(repository, mapper)
    {
        _categoryRepository = categoryRepository;
    }

    
    /** Functions */
    public async Task<IEnumerable<ProductDto>> ProductList()
    {
        var products = await Repository.FindAllAsync();
        return Mapper.Map<IEnumerable<ProductDto>>(products);
    }
    

    public async Task<CreateProductDto> CreateProduct(CreateProductDto createProductDto)
    {
        await CheckCategory(createProductDto.CategoryId);
        var product = Mapper.Map<Entities.Models.Product.Product>(createProductDto);
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
        await CheckCategory(productDto.CategoryId);
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


    private async Task<Entities.Models.Product.Product> CheckProduct(Guid id)
    {
        var product = await Repository.FindOneByAsync(p => p.Id.Equals(id));
        if (product is null)
            throw new Exception("Product is not found!");

        return product;
    }


    private async Task CheckCategory(Guid categoryId)
    {
        var category = await _categoryRepository.FindOneByAsync(c => c.Id.Equals(categoryId));
        if (category is null)
            throw new Exception("Category is not found");
    }
}