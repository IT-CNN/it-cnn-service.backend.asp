using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CNN.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Role foreign keys management
        builder.Entity<UserRole>(userRole =>
        {
            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });
        builder.Entity<Role>(role =>
        {
            ICollection<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Id = Guid.NewGuid(),
                    LongName = "Administrator",
                    Name = AppRoles.ADMIN,
                    NormalizedName= AppRoles.ADMIN
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    LongName = "Simple user",
                    Name = AppRoles.SIMPLE,
                    NormalizedName= AppRoles.SIMPLE
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    LongName = "Storekeeper",
                    Name = AppRoles.STORE,
                    NormalizedName= AppRoles.STORE
                },
            };
            role.HasData(roles);
        });
    }


}
