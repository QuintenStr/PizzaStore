using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public interface IShoppingCartService
    {
        public ShoppingCart GetCart();
        public void SaveCart(ShoppingCart cart);
        public void AddItemToCart(int id, Size size);
        public CartViewModel GetCartViewModel();
        public CartLine GetCartLineById(int id);
        public void ClearCart();
    }
}
