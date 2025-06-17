namespace Entities.Common;

public abstract class PrimaryKeyProvider
{
    public Guid Id { get; set; }
    
    protected PrimaryKeyProvider()
    {
        Id = Guid.NewGuid();
    }
}