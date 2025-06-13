using Entities.Common;

namespace Services.Common;

public static class SoftDeleteService
{
    public static void SoftDelete<T>(this T entity) where T : SoftDeleteProvider
    {
        entity.DeletedAt = DateTime.UtcNow;
        entity.IsDeleted = true;
    }
}