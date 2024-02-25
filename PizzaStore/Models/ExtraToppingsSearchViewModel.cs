using PizzaStore.Data;

namespace PizzaStore.Models
{
    public class ExtraToppingsSearchViewModel
    {
        public string? SearchByName { get; set; }
        public CartLine cartLine { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

    }
}
