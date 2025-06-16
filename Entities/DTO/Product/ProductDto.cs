using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Product;

public record ProductDto : AbstractDto
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Title must be at max 50 characters")]
    public String? Title { get; init; }
    
    
    public String? Description { get; init; }
    
    
    [Required(ErrorMessage = "Price is required")]
    [Range(10, 1000, ErrorMessage = "Price must be between 10 and 1000 values")]
    public decimal? Price { get; init; }
}