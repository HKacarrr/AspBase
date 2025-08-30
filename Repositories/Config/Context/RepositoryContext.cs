using System.Reflection;
using Entities.Common;
using Entities.Models.Auth;
using Entities.Models.Team;
using Entities.Models.Workspace;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories.Config.Context;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {}
    
    
    /** Entity Set with DbSet */
    public DbSet<Entities.Models.Product.Product> Product { get; set; }
    public DbSet<Entities.Models.Category.Category> Category { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Profile> Profile { get; set; }
    
    /** Workspace */
    public DbSet<Workspace> Workspace { get; set; }
    public DbSet<WorkspaceMember> WorkspaceMember { get; set; }
    public DbSet<WorkspaceInvite> WorkspaceInvite { get; set; }
    public DbSet<WorkspaceMemberRole> WorkspaceMemberRole { get; set; }
    
    /** Team */
    public DbSet<Team> Team { get; set; }
    public DbSet<TeamMember> TeamMember { get; set; }
    public DbSet<TeamInvite> TeamInvite { get; set; }
    public DbSet<TeamMemberRole> TeamMemberRole { get; set; }
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
        ConfigureWorkspaceSchemas(modelBuilder);
        ConfigureTeamSchemas(modelBuilder);
    }

    private void ConfigureUserSchemas(ModelBuilder modelBuilder)
    {
        var schema = "a_user";
        modelBuilder.Entity<User>(b => b.ToTable("AspNetUsers", schema));
        modelBuilder.Entity<IdentityUserClaim<string>>(b => b.ToTable("AspNetUserClaims", schema));
        modelBuilder.Entity<IdentityUserLogin<string>>(b => b.ToTable("AspNetUserLogins", schema));
        modelBuilder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("AspNetRoleClaims", schema));
        modelBuilder.Entity<IdentityUserToken<string>>(b => b.ToTable("AspNetUserTokens", schema));
        modelBuilder.Entity<Profile>(b => b.ToTable("Profile", schema));
    }
    
    private void ConfigureRoleSchemas(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>(b => b.ToTable("AspNetRoles", "a_roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(b => b.ToTable("AspNetUserRoles", "a_roles"));
    }
    
    private void ConfigureProductSchemas(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Models.Product.Product>().ToTable("product", "p_product");
    }
    
    
    private void ConfigureCategorySchemas(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Models.Category.Category>().ToTable("category", "c_category");
    }


    private void ConfigureWorkspaceSchemas(ModelBuilder modelBuilder)
    {
        var schema = "w_workspace";
        modelBuilder.Entity<Workspace>(b => b.ToTable("workspaces", schema));
        modelBuilder.Entity<WorkspaceMember>(b => b.ToTable("workspace_members", schema));
        modelBuilder.Entity<WorkspaceInvite>(b => b.ToTable("workspace_invites", schema));
        modelBuilder.Entity<WorkspaceMemberRole>(b => b.ToTable("workspace_member_roles", schema));
    }
    

    private void ConfigureTeamSchemas(ModelBuilder modelBuilder)
    {
        var schema = "t_team";
        modelBuilder.Entity<Team>(b => b.ToTable("teams", schema));
        modelBuilder.Entity<TeamMember>(b => b.ToTable("team_members", schema));
        modelBuilder.Entity<TeamInvite>(b => b.ToTable("team_invites", schema));
        modelBuilder.Entity<TeamMemberRole>(b => b.ToTable("team_member_roles", schema));
    }
}