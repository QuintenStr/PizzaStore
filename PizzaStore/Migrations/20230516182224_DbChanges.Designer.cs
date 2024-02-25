﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaStore.Data;

#nullable disable

namespace PizzaStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230516182224_DbChanges")]
    partial class DbChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IngredientOrderLine", b =>
                {
                    b.Property<int>("ExtraToppingsIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("OrderLinesOrderLineId")
                        .HasColumnType("int");

                    b.HasKey("ExtraToppingsIngredientId", "OrderLinesOrderLineId");

                    b.HasIndex("OrderLinesOrderLineId");

                    b.ToTable("ExtratoppingsOrderLine", (string)null);
                });

            modelBuilder.Entity("IngredientPizza", b =>
                {
                    b.Property<int>("IngredientsIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("PizzasPizzaId")
                        .HasColumnType("int");

                    b.HasKey("IngredientsIngredientId", "PizzasPizzaId");

                    b.HasIndex("PizzasPizzaId");

                    b.ToTable("IngredientPizza", (string)null);

                    b.HasData(
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 1
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 1
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 2
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 2
                        },
                        new
                        {
                            IngredientsIngredientId = 3,
                            PizzasPizzaId = 2
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 3
                        },
                        new
                        {
                            IngredientsIngredientId = 5,
                            PizzasPizzaId = 3
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 4
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 4
                        },
                        new
                        {
                            IngredientsIngredientId = 4,
                            PizzasPizzaId = 4
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 5
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 5
                        },
                        new
                        {
                            IngredientsIngredientId = 3,
                            PizzasPizzaId = 5
                        },
                        new
                        {
                            IngredientsIngredientId = 5,
                            PizzasPizzaId = 5
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 6
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 6
                        },
                        new
                        {
                            IngredientsIngredientId = 3,
                            PizzasPizzaId = 6
                        },
                        new
                        {
                            IngredientsIngredientId = 8,
                            PizzasPizzaId = 6
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 7
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 7
                        },
                        new
                        {
                            IngredientsIngredientId = 9,
                            PizzasPizzaId = 7
                        },
                        new
                        {
                            IngredientsIngredientId = 10,
                            PizzasPizzaId = 7
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 8
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 8
                        },
                        new
                        {
                            IngredientsIngredientId = 11,
                            PizzasPizzaId = 8
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 9
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 9
                        },
                        new
                        {
                            IngredientsIngredientId = 12,
                            PizzasPizzaId = 9
                        },
                        new
                        {
                            IngredientsIngredientId = 1,
                            PizzasPizzaId = 10
                        },
                        new
                        {
                            IngredientsIngredientId = 2,
                            PizzasPizzaId = 10
                        },
                        new
                        {
                            IngredientsIngredientId = 7,
                            PizzasPizzaId = 10
                        },
                        new
                        {
                            IngredientsIngredientId = 13,
                            PizzasPizzaId = 10
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("PizzaStore.Data.DeliveryOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("DeliveryOrders");
                });

            modelBuilder.Entity("PizzaStore.Data.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Description = "Our pizza base is meticulously handcrafted using the finest Italian flour, resulting in a perfect balance of crispiness and chewiness. It serves as a delightful foundation for all the flavors to come.",
                            ImageUrl = "base.jpg",
                            Name = "Base"
                        },
                        new
                        {
                            IngredientId = 2,
                            Description = "Our creamy Mozzarella cheese is sourced from local dairy farms, where it is expertly crafted to ensure its freshness and rich flavor. It melts beautifully, creating a gooey and indulgent experience with every bite.",
                            ImageUrl = "mozzarella.jpg",
                            Name = "Mozzarella"
                        },
                        new
                        {
                            IngredientId = 3,
                            Description = "Our succulent ham is carefully selected from premium cuts, smoked to perfection, and thinly sliced to add a delightful savory touch to your pizza. It's a classic favorite that never fails to satisfy.",
                            ImageUrl = "ham.jpg",
                            Name = "Ham"
                        },
                        new
                        {
                            IngredientId = 4,
                            Description = "Crafted with a blend of spices and cured to achieve its robust flavor, our salami adds a zesty and slightly spicy kick to your pizza. Every slice is a burst of delectable taste and authentic Italian charm.",
                            ImageUrl = "salami.jpg",
                            Name = "Salami"
                        },
                        new
                        {
                            IngredientId = 5,
                            Description = "Our fresh mushrooms are handpicked from local farms, ensuring their earthy aroma and delicate texture. These savory fungi bring a wonderful umami depth to your pizza, enhancing the overall taste experience.",
                            ImageUrl = "mushrooms.jpg",
                            Name = "Mushrooms"
                        },
                        new
                        {
                            IngredientId = 6,
                            Description = "Our farm-fresh eggs, cracked and carefully placed on your pizza, create a luscious and velvety texture. Each golden yolk adds a touch of richness, making every slice a delightful and satisfying treat.",
                            ImageUrl = "egg.jpg",
                            Name = "Egg"
                        },
                        new
                        {
                            IngredientId = 7,
                            Description = "Sourced from local gardens, our onions provide a sweet yet tangy flavor to your pizza. They are thinly sliced and caramelized to perfection, adding a hint of sweetness and a delightful crunch.",
                            ImageUrl = "onion.jpg",
                            Name = "Onion"
                        },
                        new
                        {
                            IngredientId = 8,
                            Description = "Our juicy and tropical ananas comes straight from sun-kissed plantations, offering a burst of refreshing sweetness to balance the savory elements of your pizza. It's a polarizing choice that adds a unique twist to your culinary journey.",
                            ImageUrl = "pineapple.jpg",
                            Name = "Pineapple"
                        },
                        new
                        {
                            IngredientId = 9,
                            Description = "Indulge in the creamy and tangy goodness of our carefully selected goat cheese. Made from the finest goat's milk, it brings a delightful tanginess and velvety texture to your pizza, ensuring a truly gourmet experience.",
                            ImageUrl = "goatcheese.jpg",
                            Name = "Goat cheese"
                        },
                        new
                        {
                            IngredientId = 10,
                            Description = "Our natural honey, sourced from local beekeepers, adds a touch of sweetness and complexity to your pizza. Drizzled over select ingredients, it elevates the flavors, creating a harmonious balance that will tantalize your taste buds.",
                            ImageUrl = "honey.jpg",
                            Name = "Honey"
                        },
                        new
                        {
                            IngredientId = 11,
                            Description = "Dive into the oceanic depths with our premium salmon, carefully smoked to perfection. Its delicate and buttery texture, combined with a hint of smokiness, adds a luxurious and satisfying element to your pizza.",
                            ImageUrl = "salmon.jpg",
                            Name = "Salmon"
                        },
                        new
                        {
                            IngredientId = 12,
                            Description = "Experience the exquisite taste of our thinly sliced, air-dried Parmaham. Originating from the rolling hills of Italy, each slice offers a melt-in-your-mouth sensation, delivering a burst of salty, savory goodness.",
                            ImageUrl = "parmaham.jpg",
                            Name = "Parmaham"
                        },
                        new
                        {
                            IngredientId = 13,
                            Description = "Our tuna is responsibly sourced from the pristine waters of the sea, ensuring its freshness and superior quality. With its meaty texture and mild flavor, it adds a delightful seafood twist to your pizza, perfect for seafood enthusiasts.",
                            ImageUrl = "tuna.jpg",
                            Name = "Tuna"
                        });
                });

            modelBuilder.Entity("PizzaStore.Data.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderLineId"), 1L, 1);

                    b.Property<int>("DeliveryOrderFK")
                        .HasColumnType("int");

                    b.Property<int>("PickupOrderFK")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("OrderLineId");

                    b.HasIndex("DeliveryOrderFK");

                    b.HasIndex("PickupOrderFK");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("PizzaStore.Data.PickupOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PickupDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("PickupOrders");
                });

            modelBuilder.Entity("PizzaStore.Data.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 1,
                            ImageUrl = "margherita.jpg",
                            Name = "Margherita",
                            Price = 9.0
                        },
                        new
                        {
                            PizzaId = 2,
                            ImageUrl = "prosciutto.jpg",
                            Name = "Prosciutto",
                            Price = 11.5
                        },
                        new
                        {
                            PizzaId = 3,
                            ImageUrl = "funghi.jpg",
                            Name = "Funghi",
                            Price = 11.0
                        },
                        new
                        {
                            PizzaId = 4,
                            ImageUrl = "diavola.jpg",
                            Name = "Diavola",
                            Price = 12.0
                        },
                        new
                        {
                            PizzaId = 5,
                            ImageUrl = "calzone.jpg",
                            Name = "Calzone",
                            Price = 12.99
                        },
                        new
                        {
                            PizzaId = 6,
                            ImageUrl = "hawai.jpg",
                            Name = "Hawaï",
                            Price = 12.0
                        },
                        new
                        {
                            PizzaId = 7,
                            ImageUrl = "goaty.jpg",
                            Name = "Goaty",
                            Price = 13.0
                        },
                        new
                        {
                            PizzaId = 8,
                            ImageUrl = "salmony.jpg",
                            Name = "Salmony",
                            Price = 12.0
                        },
                        new
                        {
                            PizzaId = 9,
                            ImageUrl = "alparma.jpg",
                            Name = "Al Parma",
                            Price = 13.0
                        },
                        new
                        {
                            PizzaId = 10,
                            ImageUrl = "altonno.jpg",
                            Name = "Al Tonno",
                            Price = 12.0
                        });
                });

            modelBuilder.Entity("PizzaStore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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
                });

            modelBuilder.Entity("IngredientOrderLine", b =>
                {
                    b.HasOne("PizzaStore.Data.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("ExtraToppingsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaStore.Data.OrderLine", null)
                        .WithMany()
                        .HasForeignKey("OrderLinesOrderLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IngredientPizza", b =>
                {
                    b.HasOne("PizzaStore.Data.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaStore.Data.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasPizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PizzaStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PizzaStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PizzaStore.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaStore.Data.OrderLine", b =>
                {
                    b.HasOne("PizzaStore.Data.DeliveryOrder", "DeliveryOrder")
                        .WithMany("OrderLines")
                        .HasForeignKey("DeliveryOrderFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaStore.Data.PickupOrder", "PickupOrder")
                        .WithMany("OrderLines")
                        .HasForeignKey("PickupOrderFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaStore.Data.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryOrder");

                    b.Navigation("PickupOrder");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaStore.Data.DeliveryOrder", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("PizzaStore.Data.PickupOrder", b =>
                {
                    b.Navigation("OrderLines");
                });
#pragma warning restore 612, 618
        }
    }
}
