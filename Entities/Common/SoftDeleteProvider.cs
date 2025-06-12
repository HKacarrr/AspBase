namespace Entities.Common;

public abstract class SoftDeleteProvider : DatetimeProvider
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}