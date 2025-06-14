using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Product;

[ApiController]
[Route("products")]
public class ProductController : AbstractController
{
    private readonly ServiceManager _serviceManager;
    
    public ProductController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    
    [HttpGet]
    public async Task<List<Entities.Product.Product>> List()
    {
        return await _serviceManager.ProductService.ProductList();
    }
}