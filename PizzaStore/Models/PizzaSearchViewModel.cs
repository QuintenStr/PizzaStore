using PizzaStore.Data;

namespace PizzaStore.Models
{
    public class PizzaSearchViewModel
    {
        public string? Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public List<CheckBoxModel> CheckBoxItems { get; set; } = new List<CheckBoxModel>();
        public IEnumerable<Pizza> pizzas { get; set; }
    }
}
