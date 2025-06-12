using System.Reflection;
using Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Repositories.Config.Context;

public class RepositoryContext : IdentityDbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {}
    
    public DbSet<Entities.Product.Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    
    private void SetDatetimeData()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is DatetimeProvider &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (DatetimeProvider)entry.Entity;

            if (entry.State == EntityState.Added)
                entity.CreatedAt = DateTime.UtcNow;

            entity.UpdatedAt = DateTime.UtcNow;
        }

        var softDeletedEntries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is SoftDeleteProvider && e.State == EntityState.Deleted);

        foreach (var entry in softDeletedEntries)
        {
            entry.State = EntityState.Modified;
            var entity = (SoftDeleteProvider)entry.Entity;
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
        }
    }
}