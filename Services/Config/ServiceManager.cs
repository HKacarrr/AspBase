using Services.Category;
using Services.Product;

namespace Services.Config;

public class ServiceManager
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public ServiceManager(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public ProductService ProductService => _productService;
    public CategoryService CategoryService => _categoryService;
}