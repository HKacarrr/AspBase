using AutoMapper;
using Entities.DTO.Workspace.Workspace;
using Repositories;

namespace Services.Workspace;

public class WorkspaceService : AbstractWorkspaceService<Entities.Models.Workspace.Workspace>
{
    public WorkspaceService(IBaseRepository<Entities.Models.Workspace.Workspace> repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    public async Task<IEnumerable<WorkspaceDto>> WorkspaceList()
    {
        var workspaces = await Repository.FindAllAsync();
        return Mapper.Map<IEnumerable<WorkspaceDto>>(workspaces);
    }
    
    
    public async Task<CreateWorkspaceDto> CreateWorkspace(CreateWorkspaceDto createWorkspaceDto)
    {
        var workspace = Mapper.Map<Entities.Models.Workspace.Workspace>(createWorkspaceDto);
        await Repository.AddAsync(workspace);
        Repository.SaveAsync();

        return Mapper.Map<CreateWorkspaceDto>(workspace);
    }
    
    
    public async Task<WorkspaceDto> GetWorkspaceById(Guid id)
    {
        var workspace = await CheckWorkspace(id);
        return Mapper.Map<WorkspaceDto>(workspace);
    }
    
    
    public async Task UpdateWorkspace(Guid id, WorkspaceDto workspaceDto)
    {
        var updatingWorkspace = await CheckWorkspace(id);
        Mapper.Map(workspaceDto, updatingWorkspace);
        Repository.Update(updatingWorkspace);
        Repository.SaveAsync();
    }
    
    
    public async Task DeleteWorkspace(Guid id)
    {
        var deletingWorkspace = await CheckWorkspace(id);
        Repository.Delete(deletingWorkspace);
        Repository.SaveAsync();
    }

    
    /** PRIVATE FUNCTIONS */
    
    private async Task<Entities.Models.Workspace.Workspace> CheckWorkspace(Guid workspaceId)
    {
        var workspace = await Repository.FindOneByAsync(c => c.Id.Equals(workspaceId));
        if (workspace is null)
            throw new Exception("Workspace is not found");

        return workspace;
    }
}