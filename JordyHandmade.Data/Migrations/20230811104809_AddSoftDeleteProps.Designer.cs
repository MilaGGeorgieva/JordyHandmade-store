﻿// <auto-generated />
using System;
using JordyHandmade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JordyHandmade.Data.Migrations
{
    [DbContext(typeof(JordyHandmadeDbContext))]
    [Migration("20230811104809_AddSoftDeleteProps")]
    partial class AddSoftDeleteProps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JordyHandmade.Data.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Street with number");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");

                    b.HasComment("Adresses table");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Category name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Category description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Product categories table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Home decoration",
                            Description = "Home decoration for living room, kitchen, sleeping rooms. Pillows, placemats, Christmas, Easter and other occasions decorations. ",
                            IsActive = false
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Bags and totes",
                            Description = "Crochet, denim or other fabrics women bags, totes, backpacks, beach bags.",
                            IsActive = false
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Embroidered items",
                            Description = "Hand embroidered shirts, denim items, dresses, different style embroidery including Bulgarian traditional.",
                            IsActive = false
                        });
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.ClientCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AggregatedSales")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Aggregated customer sales");

                    b.Property<int?>("BonusPoints")
                        .HasColumnType("int")
                        .HasComment("Earned bonus points");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Last updated on");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ClientCards");

                    b.HasComment("Card for bonuses table");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Customer First and Last name");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasComment("Rating of the customer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CardId")
                        .IsUnique()
                        .HasFilter("[CardId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("Customers table");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Discount")
                        .HasColumnType("int")
                        .HasComment("Given customer discount");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date order completed");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date order made");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasComment("Order progress");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Total amount of purchase");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasComment("Customer orders table");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.OrderProduct", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.PartsInProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Part name");

                    b.Property<decimal>("PartPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Part price");

                    b.Property<double>("QuantityInStock")
                        .HasColumnType("float")
                        .HasComment("Part quantity left");

                    b.Property<string>("QuantityMeasureUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Quantity measure unit");

                    b.Property<double>("QuantityPurchased")
                        .HasColumnType("float")
                        .HasComment("Part quantity purchased");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("PartsInProducts");

                    b.HasComment("Parts in the product table");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 8, 11, 10, 48, 9, 49, DateTimeKind.Utc).AddTicks(7189))
                        .HasComment("Date product was created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Product description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Product photo");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Product name");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Product price");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int")
                        .HasComment("Product quantity available");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasComment("Product table");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01e29ca1-a601-48fe-83b9-5d1eef994fd3"),
                            CategoryId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!",
                            ImageUrl = "/Images/ProductImages/HeartPillows.jpg",
                            IsObsolete = false,
                            Name = "Heart pillow",
                            Price = 20.00m,
                            QuantityInStock = 6
                        },
                        new
                        {
                            Id = new Guid("8fda1480-97fb-4028-b8f3-a9c2841925be"),
                            CategoryId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!",
                            ImageUrl = "/Images/ProductImages/SunnyBackpack.jpg",
                            IsObsolete = false,
                            Name = "Bright sunny backpack",
                            Price = 25.00m,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = new Guid("08a87a86-b3d3-4844-ac38-4866d4ebcfcd"),
                            CategoryId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ",
                            ImageUrl = "/Images/ProductImages/DenimBagSet.jpg",
                            IsObsolete = false,
                            Name = "Girlish style denim bag set",
                            Price = 29.00m,
                            QuantityInStock = 1
                        });
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.ProductPart", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PartQuantity")
                        .HasColumnType("float");

                    b.HasKey("ProductId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("ProductsParts");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Supplier email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Supplier phone number");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Supplier name");

                    b.Property<string>("Website")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Supplier web site");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Suppliers");

                    b.HasComment("Supplier of parts table");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Town Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TownName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Town name");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasComment("Town 4-digit zip code");

                    b.HasKey("Id");

                    b.ToTable("Towns");

                    b.HasComment("Table with towns");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Address", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Town", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Customer", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JordyHandmade.Data.Models.ClientCard", "Card")
                        .WithOne("Customer")
                        .HasForeignKey("JordyHandmade.Data.Models.Customer", "CardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Address");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Order", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JordyHandmade.Data.Models.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.PartsInProduct", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Supplier", "Supplier")
                        .WithMany("ProductParts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Product", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.ProductPart", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.PartsInProduct", "PartsInProduct")
                        .WithMany("PartProducts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JordyHandmade.Data.Models.Product", "Product")
                        .WithMany("ProductParts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartsInProduct");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Supplier", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Address", "Address")
                        .WithOne("Supplier")
                        .HasForeignKey("JordyHandmade.Data.Models.Supplier", "AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JordyHandmade.Data.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("JordyHandmade.Data.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Address", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.ClientCard", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.PartsInProduct", b =>
                {
                    b.Navigation("PartProducts");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Product", b =>
                {
                    b.Navigation("ProductOrders");

                    b.Navigation("ProductParts");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Supplier", b =>
                {
                    b.Navigation("ProductParts");
                });

            modelBuilder.Entity("JordyHandmade.Data.Models.Town", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
