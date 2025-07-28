using Entities.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Product;

[ApiController]
[Route("api/products")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ProductController : AbstractProductController
{
    private readonly ServiceManager _serviceManager;
    
    public ProductController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var products = await _serviceManager.ProductService.ProductList();
        return Ok(products);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto productDto)
    {
        var product = await _serviceManager.ProductService.CreateProduct(productDto);
        return Ok(product);
    }
    
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Read([FromRoute] Guid id)
    {
        var product = await _serviceManager.ProductService.GetProductById(id);
        return Ok(product);
    }
    
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductDto productDto)
    {
        await _serviceManager.ProductService.UpdateProduct(id, productDto);
        return Ok(productDto);
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _serviceManager.ProductService.DeleteProduct(id);
        return Ok();
    }
}