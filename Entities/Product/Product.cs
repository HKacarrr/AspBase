using Entities.Common;

namespace Entities.Product;

public class Product : DatetimeProvider
{
    public string? Title { get; set; }

    public string? Description { get; set; }
    
    public decimal Price { get; set; }
}