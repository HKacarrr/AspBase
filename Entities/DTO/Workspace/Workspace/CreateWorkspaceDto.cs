using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Workspace.Workspace;

public class CreateWorkspaceDto
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Title must be at max 50 characters")]
    public string? Title { get; init; }
    
    public string? Description { get; init; }
    
    public string? Logo { get; init; }
    
    public string? Email { get; init; }
    
    public string? Phone { get; init; }
    
    public string? Website { get; init; }
    
    public bool? Enable { get; init; }
}