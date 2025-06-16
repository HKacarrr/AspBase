using Entities.DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Product;

[ApiController]
public class ProductController : AbstractProductController
{
    private readonly ServiceManager _serviceManager;
    
    public ProductController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    
    [HttpGet]
    public async Task<IEnumerable<ProductDto>> List()
    {
        return await _serviceManager.ProductService.ProductList();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var products = await _serviceManager.ProductService.ProductRepository.FindAllAsync();
        // var products = await _serviceManager.ProductService.ProductList();
        return Ok(products);
    }
    
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Read()
    {
        var product = await _serviceManager.ProductService.ProductList();
        return Ok();
    }
    
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Entities.Product.Product updatingProduct)
    {
        var product = await _serviceManager.ProductService.ProductList();
        return Ok();
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _serviceManager.ProductService.ProductList();
        return Ok();
    }
}