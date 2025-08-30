using Entities.DTO.Workspace.Workspace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Config;

namespace Presentation.Workspace;


[ApiController]
[Route("api/workspaces")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class WorkspaceController : AbstractWorkspaceController
{
    private readonly ServiceManager _serviceManager;
    
    public WorkspaceController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var workspaces = await _serviceManager.WorkspaceService.WorkspaceList();
        return Ok(workspaces);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkspaceDto createWorkspaceDto)
    {
        var workspace = await _serviceManager.WorkspaceService.CreateWorkspace(createWorkspaceDto);
        return Ok(workspace);
    }
    
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Read([FromRoute] Guid id)
    {
        var product = await _serviceManager.ProductService.GetProductById(id);
        return Ok(product);
    }
    
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WorkspaceDto workspaceDto)
    {
        await _serviceManager.WorkspaceService.UpdateWorkspace(id, workspaceDto);
        return Ok(workspaceDto);
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _serviceManager.WorkspaceService.DeleteWorkspace(id);
        return Ok();
    }
}