namespace PizzaStore.Data
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }

        public Size PizzaSize { get; set; }

        public ICollection<Ingredient> ExtraToppings { get; set; }

        public double Price { get; set; }

        public PickupOrder? PickupOrder { get; set; }
        public int? PickupOrderFK { get; set; }

        public DeliveryOrder? DeliveryOrder { get; set; }
        public int? DeliveryOrderFK { get; set; }

    }
}
