using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Team Leader",
                NormalizedName = "TEAM_LEADER"
            },
            new IdentityRole
            {
                Name = "Team Member",
                NormalizedName = "TEAM_MEMBER"
            },
            new IdentityRole
            {
                Name = "Workspace Leader",
                NormalizedName = "WORKSPACE_LEADER"
            },
            new IdentityRole
            {
                Name = "Workspace Member",
                NormalizedName = "WORKSPACE_MEMBER"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}