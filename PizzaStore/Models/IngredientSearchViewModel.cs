using PizzaStore.Data;

namespace PizzaStore.Models
{
    public class IngredientSearchViewModel
    {
        public string? Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

    }
}
