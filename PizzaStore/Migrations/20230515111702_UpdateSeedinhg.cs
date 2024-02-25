using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    public partial class UpdateSeedinhg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Our pizza base is meticulously handcrafted using the finest Italian flour, resulting in a perfect balance of crispiness and chewiness. It serves as a delightful foundation for all the flavors to come.", "base.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Our creamy Mozzarella cheese is sourced from local dairy farms, where it is expertly crafted to ensure its freshness and rich flavor. It melts beautifully, creating a gooey and indulgent experience with every bite.", "mozzarella.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Our succulent ham is carefully selected from premium cuts, smoked to perfection, and thinly sliced to add a delightful savory touch to your pizza. It's a classic favorite that never fails to satisfy.", "ham.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Crafted with a blend of spices and cured to achieve its robust flavor, our salami adds a zesty and slightly spicy kick to your pizza. Every slice is a burst of delectable taste and authentic Italian charm.", "salami.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Our fresh mushrooms are handpicked from local farms, ensuring their earthy aroma and delicate texture. These savory fungi bring a wonderful umami depth to your pizza, enhancing the overall taste experience.", "mushrooms.jpg", "Mushrooms" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Our farm-fresh eggs, cracked and carefully placed on your pizza, create a luscious and velvety texture. Each golden yolk adds a touch of richness, making every slice a delightful and satisfying treat.", "egg.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Sourced from local gardens, our onions provide a sweet yet tangy flavor to your pizza. They are thinly sliced and caramelized to perfection, adding a hint of sweetness and a delightful crunch.", "onion.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Our juicy and tropical ananas comes straight from sun-kissed plantations, offering a burst of refreshing sweetness to balance the savory elements of your pizza. It's a polarizing choice that adds a unique twist to your culinary journey.", "pineapple.jpg", "Pineapple" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Indulge in the creamy and tangy goodness of our carefully selected goat cheese. Made from the finest goat's milk, it brings a delightful tanginess and velvety texture to your pizza, ensuring a truly gourmet experience.", "goatcheese.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Our natural honey, sourced from local beekeepers, adds a touch of sweetness and complexity to your pizza. Drizzled over select ingredients, it elevates the flavors, creating a harmonious balance that will tantalize your taste buds.", "honey.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Dive into the oceanic depths with our premium salmon, carefully smoked to perfection. Its delicate and buttery texture, combined with a hint of smokiness, adds a luxurious and satisfying element to your pizza.", "salmon.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Experience the exquisite taste of our thinly sliced, air-dried Parmaham. Originating from the rolling hills of Italy, each slice offers a melt-in-your-mouth sensation, delivering a burst of salty, savory goodness.", "parmaham.jpg" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Our tuna is responsibly sourced from the pristine waters of the sea, ensuring its freshness and superior quality. With its meaty texture and mild flavor, it adds a delightful seafood twist to your pizza, perfect for seafood enthusiasts.", "tuna.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { null, null, "Shrooms" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { null, null, "Ananas" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { null, null });
        }
    }
}
