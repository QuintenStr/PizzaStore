using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaStore;Trusted_Connection=True;");
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<PickupOrder> PickupOrders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeliveryOrder>().HasKey(x => x.OrderId);
            modelBuilder.Entity<PickupOrder>().HasKey(x => x.OrderId);

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient() { IngredientId = 1, Name = "Base", ImageUrl = "base.jpg", Description = "Our pizza base is meticulously handcrafted using the finest Italian flour, resulting in a perfect balance of crispiness and chewiness. It serves as a delightful foundation for all the flavors to come." },
                new Ingredient() { IngredientId = 2, Name = "Mozzarella", ImageUrl = "mozzarella.jpg", Description = "Our creamy Mozzarella cheese is sourced from local dairy farms, where it is expertly crafted to ensure its freshness and rich flavor. It melts beautifully, creating a gooey and indulgent experience with every bite." },
                new Ingredient() { IngredientId = 3, Name = "Ham", ImageUrl = "ham.jpg", Description = "Our succulent ham is carefully selected from premium cuts, smoked to perfection, and thinly sliced to add a delightful savory touch to your pizza. It's a classic favorite that never fails to satisfy." },
                new Ingredient() { IngredientId = 4, Name = "Salami", ImageUrl = "salami.jpg", Description = "Crafted with a blend of spices and cured to achieve its robust flavor, our salami adds a zesty and slightly spicy kick to your pizza. Every slice is a burst of delectable taste and authentic Italian charm." },
                new Ingredient() { IngredientId = 5, Name = "Mushrooms", ImageUrl = "mushrooms.jpg", Description = "Our fresh mushrooms are handpicked from local farms, ensuring their earthy aroma and delicate texture. These savory fungi bring a wonderful umami depth to your pizza, enhancing the overall taste experience." },
                new Ingredient() { IngredientId = 6, Name = "Egg", ImageUrl = "egg.jpg", Description = "Our farm-fresh eggs, cracked and carefully placed on your pizza, create a luscious and velvety texture. Each golden yolk adds a touch of richness, making every slice a delightful and satisfying treat." },
                new Ingredient() { IngredientId = 7, Name = "Onion", ImageUrl = "onion.jpg", Description = "Sourced from local gardens, our onions provide a sweet yet tangy flavor to your pizza. They are thinly sliced and caramelized to perfection, adding a hint of sweetness and a delightful crunch." },
                new Ingredient() { IngredientId = 8, Name = "Pineapple", ImageUrl = "pineapple.jpg", Description = "Our juicy and tropical ananas comes straight from sun-kissed plantations, offering a burst of refreshing sweetness to balance the savory elements of your pizza. It's a polarizing choice that adds a unique twist to your culinary journey." },
                new Ingredient() { IngredientId = 9, Name = "Goat cheese", ImageUrl = "goatcheese.jpg", Description = "Indulge in the creamy and tangy goodness of our carefully selected goat cheese. Made from the finest goat's milk, it brings a delightful tanginess and velvety texture to your pizza, ensuring a truly gourmet experience." },
                new Ingredient() { IngredientId = 10, Name = "Honey", ImageUrl= "honey.jpg", Description = "Our natural honey, sourced from local beekeepers, adds a touch of sweetness and complexity to your pizza. Drizzled over select ingredients, it elevates the flavors, creating a harmonious balance that will tantalize your taste buds." },
                new Ingredient() { IngredientId = 11, Name = "Salmon", ImageUrl = "salmon.jpg", Description = "Dive into the oceanic depths with our premium salmon, carefully smoked to perfection. Its delicate and buttery texture, combined with a hint of smokiness, adds a luxurious and satisfying element to your pizza." },
                new Ingredient() { IngredientId = 12, Name = "Parmaham", ImageUrl = "parmaham.jpg", Description = "Experience the exquisite taste of our thinly sliced, air-dried Parmaham. Originating from the rolling hills of Italy, each slice offers a melt-in-your-mouth sensation, delivering a burst of salty, savory goodness." },
                new Ingredient() { IngredientId = 13, Name = "Tuna", ImageUrl = "tuna.jpg", Description = "Our tuna is responsibly sourced from the pristine waters of the sea, ensuring its freshness and superior quality. With its meaty texture and mild flavor, it adds a delightful seafood twist to your pizza, perfect for seafood enthusiasts." }
            );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { PizzaId = 1, Name = "Margherita", Price = 9, ImageUrl = "margherita.jpg" },
                new Pizza() { PizzaId = 2, Name = "Prosciutto", Price = 11.5, ImageUrl = "prosciutto.jpg" },
                new Pizza() { PizzaId = 3, Name = "Funghi", Price = 11, ImageUrl = "funghi.jpg" },
                new Pizza() { PizzaId = 4, Name = "Diavola", Price = 12, ImageUrl = "diavola.jpg" },
                new Pizza() { PizzaId = 5, Name = "Calzone", Price = 12.99, ImageUrl = "calzone.jpg" },
                new Pizza() { PizzaId = 6, Name = "Hawaï", Price = 12, ImageUrl = "hawai.jpg" },
                new Pizza() { PizzaId = 7, Name = "Goaty", Price = 13, ImageUrl = "goaty.jpg" },
                new Pizza() { PizzaId = 8, Name = "Salmony", Price = 12, ImageUrl = "salmony.jpg" },
                new Pizza() { PizzaId = 9, Name = "Al Parma", Price = 13, ImageUrl = "alparma.jpg" },
                new Pizza() { PizzaId = 10, Name = "Al Tonno", Price = 12, ImageUrl = "altonno.jpg" }
            );

            modelBuilder.Entity<OrderLine>()
                .HasOne(x => x.PickupOrder)
                .WithMany(x => x.OrderLines)
                .HasForeignKey(x => x.PickupOrderFK);

            modelBuilder.Entity<OrderLine>()
                .HasOne(x => x.DeliveryOrder)
                .WithMany(x => x.OrderLines)
                .HasForeignKey(x => x.DeliveryOrderFK);

            modelBuilder.Entity<OrderLine>()
                .HasMany(e => e.ExtraToppings)
                .WithMany(e => e.OrderLines)
                .UsingEntity(j => j
                    .ToTable("ExtratoppingsOrderLine"));

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Ingredients)
                .WithMany(e => e.Pizzas)
                .UsingEntity(j => j
                    .ToTable("IngredientPizza")
                    .HasData(
                        new { PizzasPizzaId = 1, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 1, IngredientsIngredientId = 2 },

                        new { PizzasPizzaId = 2, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 2, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 2, IngredientsIngredientId = 3 },

                        new { PizzasPizzaId = 3, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 3, IngredientsIngredientId = 5 },

                        new { PizzasPizzaId = 4, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 4, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 4, IngredientsIngredientId = 4 },

                        new { PizzasPizzaId = 5, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 5, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 5, IngredientsIngredientId = 3 },
                        new { PizzasPizzaId = 5, IngredientsIngredientId = 5 },

                        new { PizzasPizzaId = 6, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 6, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 6, IngredientsIngredientId = 3 },
                        new { PizzasPizzaId = 6, IngredientsIngredientId = 8 },

                        new { PizzasPizzaId = 7, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 7, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 7, IngredientsIngredientId = 9 },
                        new { PizzasPizzaId = 7, IngredientsIngredientId = 10 },

                        new { PizzasPizzaId = 8, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 8, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 8, IngredientsIngredientId = 11 },

                        new { PizzasPizzaId = 9, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 9, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 9, IngredientsIngredientId = 12 },

                        new { PizzasPizzaId = 10, IngredientsIngredientId = 1 },
                        new { PizzasPizzaId = 10, IngredientsIngredientId = 2 },
                        new { PizzasPizzaId = 10, IngredientsIngredientId = 7 },
                        new { PizzasPizzaId = 10, IngredientsIngredientId = 13 }
                    ));
        }
    }
}