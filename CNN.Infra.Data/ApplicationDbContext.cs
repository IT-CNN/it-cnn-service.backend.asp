using CNN.Core.Domain;
using CNN.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CNN.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public DbSet<Quantity> Quantities { get; set; }
    public DbSet<UnitPrice> UnitPrices { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Default admin user
        var adminId = Guid.NewGuid();
        var hasher = new PasswordHasher<User>();

        builder.Entity<User>(u =>
        {
            u.HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                NormalizedUserName = "ADMIN",
                BirthDate = DateTime.UtcNow,
                PasswordHash = hasher.HashPassword(null, DefaultParams.defaultPwd)
            });
        });

        // Role foreign keys management
        var adminRoleId = Guid.NewGuid();

        builder.Entity<Role>(role =>
        {
            ICollection<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Id = adminRoleId,
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

            userRole.HasData(new UserRole
            {
                UserId = adminId,
                RoleId = adminRoleId
            });
        });

        // Sequence
        builder.HasSequence<int>("ProductCodes").StartsAt(1).IncrementsBy(1);

        // Product
        builder.Entity<Product>(product =>
        {
            product
            .HasIndex(p => p.Name)
            .IsUnique();
            product
            .Property(p => p.Code)
            .HasDefaultValueSql("N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')");
        });
        builder.Entity<Category>(category =>
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Category"
                }
            };
            category.HasData(categories);
        });

        // Client
        builder.Entity<Client>(client =>
        {
            client.HasIndex(c => c.PhoneNumber).IsUnique();
            var clients = new List<Client>
            {
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "client 1",
                    PhoneNumber = "690981056"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "client 2",
                    PhoneNumber = "690981057"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "client 3",
                    PhoneNumber = "690981058"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "client 4",
                    PhoneNumber = "690981059"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "client 5",
                    PhoneNumber = "690981060"
                },
            };
            client.HasData(clients);
        });
    }
}
