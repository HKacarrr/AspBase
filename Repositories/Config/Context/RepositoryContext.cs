using System.Reflection;
using Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = GetEntries();
        foreach (var entry in entries)
            SetDatetimeColumns(entry);

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetDatetimeColumns(EntityEntry entry)
    {
        if (entry.Entity is not DatetimeProvider entity) return;
        if (entry.State == EntityState.Added)
            entity.CreatedAt = DateTime.UtcNow;

        entity.UpdatedAt = DateTime.UtcNow;
    }

    private IEnumerable<EntityEntry> GetEntries()
    {
        return ChangeTracker.Entries()
            .Where(e => e.Entity is DatetimeProvider && e.State == EntityState.Added || e.State == EntityState.Modified);
    }
}