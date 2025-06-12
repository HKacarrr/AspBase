namespace Entities.Common;

public abstract class DatetimeProvider : PrimaryKeyProvider
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}