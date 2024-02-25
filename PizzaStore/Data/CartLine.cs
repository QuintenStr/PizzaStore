namespace PizzaStore.Data
{
    public class CartLine
    {
        private static int lastId = 1;

        public int CartLineId { get; private set; }
        public Pizza Pizza { get; set; }
        public Size PizzaSize { get; set; }
        public List<IngredientExtraToppingCartLineItem> ExtraToppings { get; set; } = new List<IngredientExtraToppingCartLineItem>();
        public string SubtotalExtraToppings { get; set; }
        public string SubtotalPrice { get; set; }
        public string SubtotalTotal { get; set; }
        public double TotalPriceCartLine { get; set; }

        public CartLine(int cartLineId = -1)
        {
            if (cartLineId != -1)
            {
                CartLineId = cartLineId;
            }
            else
            {
                CartLineId = lastId;
                lastId++;
            }
        }
    }
}
