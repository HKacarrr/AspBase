using Entities.Common;

namespace Entities.Models.Category;

public class Category : DatetimeProvider
{
    public string? Title { get; set; }

    public bool? active { get; set; }
    
    public ICollection<Product.Product>? Products { get; set; }

    public Category()
    {
        active = true;
    }
}