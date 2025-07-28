using Entities.DTO.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Category;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoryController : AbstractCategoryController
{
    private readonly ServiceManager _serviceManager;
    
    public CategoryController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var categories = await _serviceManager.CategoryService.CategoryList();
        return Ok(categories);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
    {
        var category = await _serviceManager.CategoryService.CreateCategory(createCategoryDto);
        return Ok(category);
    }
    
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Read([FromRoute] Guid id)
    {
        var category = await _serviceManager.CategoryService.GetCategoryById(id);
        return Ok(category);
    }
    
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateCategoryDto createCategoryDto)
    {
        var category = await _serviceManager.CategoryService.UpdateCategory(id, createCategoryDto);
        return Ok(category);
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _serviceManager.CategoryService.DeleteCategory(id);
        return Ok();
    }
}