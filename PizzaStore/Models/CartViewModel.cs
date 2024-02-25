using PizzaStore.Data;

namespace PizzaStore.Models
{
    public class CartViewModel
    {
        public List<CartLine>? CartLines { get; set; } = new List<CartLine>();
        public double TotalPrice { get; set; } = 0;
    }
}
