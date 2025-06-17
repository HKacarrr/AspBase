using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Category;

public record CategoryDto : AbstractDto
{
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; init; }
    
    [DefaultValue(true)]
    public bool? active { get; set; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime UpdatedAt { get; init; }
}