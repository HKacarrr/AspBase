using Services.Product;

namespace Services.Config;

public class ServiceManager
{
    private readonly ProductService _productService;

    public ServiceManager(ProductService productService)
    {
        _productService = productService;
    }

    public ProductService ProductService => _productService;
}