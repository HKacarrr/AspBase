using Entities.DTO.Category;
using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Category;

[ApiController]
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
        return Ok();
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
    {
        return Ok();
    }
    
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Read([FromRoute] int id)
    {
        return Ok();
    }
    
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCategoryDto createCategoryDto)
    {
        return Ok();
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok();
    }
}