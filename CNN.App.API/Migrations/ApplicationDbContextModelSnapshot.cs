﻿// <auto-generated />
using System;
using CNN.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CNN.App.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence<int>("ProductCodes");

            modelBuilder.Entity("CNN.Core.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4f0e3ecc-7fde-4e6a-a98d-5160282a7db8"),
                            Description = "",
                            Name = "Category"
                        });
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54c7aa39-1333-4132-920d-180a1cc52938"),
                            CreatedAt = new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4908),
                            IsActive = true,
                            Name = "client 1",
                            PhoneNumber = "690981056"
                        },
                        new
                        {
                            Id = new Guid("90ec0c0f-2fc5-4796-ae6c-207fd0e38aba"),
                            CreatedAt = new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4926),
                            IsActive = true,
                            Name = "client 2",
                            PhoneNumber = "690981057"
                        },
                        new
                        {
                            Id = new Guid("5979fc9f-03d4-4d4b-8894-26b6b766df99"),
                            CreatedAt = new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4928),
                            IsActive = true,
                            Name = "client 3",
                            PhoneNumber = "690981058"
                        },
                        new
                        {
                            Id = new Guid("5112ab74-b816-4a57-9603-8a91344147ec"),
                            CreatedAt = new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4931),
                            IsActive = true,
                            Name = "client 4",
                            PhoneNumber = "690981059"
                        },
                        new
                        {
                            Id = new Guid("18c7f39d-2fe9-43bf-8524-0e4591772fa9"),
                            CreatedAt = new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4933),
                            IsActive = true,
                            Name = "client 5",
                            PhoneNumber = "690981060"
                        });
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaseSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Quantity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Quantities");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d4ada61-b06d-44d9-a770-b03bbbfb924f"),
                            LongName = "Administrator",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("799b43dc-ddb5-4981-a9d6-e155fe765ed6"),
                            LongName = "Simple user",
                            Name = "SIMPLE",
                            NormalizedName = "SIMPLE"
                        },
                        new
                        {
                            Id = new Guid("9006630d-a5cf-4087-9e83-32a34355910a"),
                            LongName = "Storekeeper",
                            Name = "STORE",
                            NormalizedName = "STORE"
                        });
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.UnitPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("UnitPrices");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivate")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7401736f-4c1f-44de-b76c-a72eb789d6f4"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 3, 28, 14, 3, 22, 288, DateTimeKind.Utc).AddTicks(4466),
                            ConcurrencyStamp = "d748742d-4d31-49f2-b51b-96c8e82be0fc",
                            CreatedAt = new DateTime(2023, 3, 28, 15, 3, 22, 288, DateTimeKind.Local).AddTicks(4419),
                            EmailConfirmed = false,
                            FirstName = "admin",
                            IsActivate = true,
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEAqFUAR6kYj4co5rXy1FNRkCjl5jCABSHYN16yMq105z4CTM5OISt4wFM/bTfmHi9Q==",
                            PhoneNumberConfirmed = false,
                            Picture = "default\\default-user.png",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("7401736f-4c1f-44de-b76c-a72eb789d6f4"),
                            RoleId = new Guid("3d4ada61-b06d-44d9-a770-b03bbbfb924f")
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Quantity", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.Product", "Product")
                        .WithMany("Quantities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.UnitPrice", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.Product", "Product")
                        .WithMany("Prices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CNN.Core.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CNN.Core.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CNN.Core.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("Prices");

                    b.Navigation("Quantities");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CNN.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
