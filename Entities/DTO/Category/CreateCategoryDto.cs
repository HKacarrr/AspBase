using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Category;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; init; }
    
    [DefaultValue(true)]
    public bool? active { get; set; }
}