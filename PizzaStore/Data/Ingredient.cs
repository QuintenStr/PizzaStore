using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Data
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Pizza>? Pizzas { get; set; }
        public ICollection<OrderLine>? OrderLines { get; set; }

    }
}
