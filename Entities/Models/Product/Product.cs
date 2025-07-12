using Entities.Common;

namespace Entities.Models.Product;

public class Product : DatetimeProvider
{
    public string? Title { get; set; }

    public string? Description { get; set; }
    
    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }

    public Category.Category Category { get; set; }
}