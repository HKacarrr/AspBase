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
    public async Task<List<Entities.Product.Product>> List()
    {
        return await _serviceManager.ProductService.ProductList();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var product = await _serviceManager.ProductService.ProductList();
        return Ok();
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