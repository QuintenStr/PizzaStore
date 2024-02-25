namespace PizzaStore.Data
{
    public class IngredientExtraToppingCartLineItem : Ingredient
    {
        private static int lastId = 1;
        public int Id { get; private set; }

        public IngredientExtraToppingCartLineItem(int id = -1)
        {
            if (id != -1)
            {
                Id = id;
            }
            else
            {
                Id = lastId;
                lastId++;
            }
        }
    }
}
