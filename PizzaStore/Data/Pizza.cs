namespace PizzaStore.Data
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}
