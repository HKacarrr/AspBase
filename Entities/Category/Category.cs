using Entities.Common;

namespace Entities.Category;

public class Category : DatetimeProvider
{
    public string? Title { get; set; }

    public bool? active { get; set; }

    public Category()
    {
        active = true;
    }
}