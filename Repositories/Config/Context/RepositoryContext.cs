using System.Reflection;
using Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories.Config.Context;

public class RepositoryContext : IdentityDbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {}
    
    
    /** Entity Set with DbSet */
    public DbSet<Entities.Product.Product> Product { get; set; }
    public DbSet<Entities.Category.Category> Category { get; set; }
    /** */
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        // Schemas 
        ConfigureDatabaseSchemas(modelBuilder);
        
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


    
    /** Schemas Settings */
    private void ConfigureDatabaseSchemas(ModelBuilder modelBuilder)
    {
        ConfigureProductSchemas(modelBuilder);
        ConfigureUserSchemas(modelBuilder);
        ConfigureRoleSchemas(modelBuilder);
        ConfigureCategorySchemas(modelBuilder);
    }

    private void ConfigureUserSchemas(ModelBuilder modelBuilder)
    {
        var schema = "a_user";
        modelBuilder.Entity<IdentityUser>(b => b.ToTable("AspNetUsers", schema));
        modelBuilder.Entity<IdentityUserClaim<string>>(b => b.ToTable("AspNetUserClaims", schema));
        modelBuilder.Entity<IdentityUserLogin<string>>(b => b.ToTable("AspNetUserLogins", schema));
        modelBuilder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("AspNetRoleClaims", schema));
        modelBuilder.Entity<IdentityUserToken<string>>(b => b.ToTable("AspNetUserTokens", schema));
    }
    
    private void ConfigureRoleSchemas(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>(b => b.ToTable("AspNetRoles", "a_roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(b => b.ToTable("AspNetUserRoles", "a_roles"));
    }
    
    private void ConfigureProductSchemas(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Product.Product>().ToTable("product", "p_product");
    }
    
    
    private void ConfigureCategorySchemas(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Category.Category>().ToTable("category", "c_category");
    }
}