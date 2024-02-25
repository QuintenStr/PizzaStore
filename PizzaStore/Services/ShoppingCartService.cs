using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private readonly IPizzaService _pizzaService;
        private readonly IIngredientService _ingredientService;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, IPizzaService pizzaService, IIngredientService ingredientService)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _pizzaService = pizzaService;
            _ingredientService = ingredientService;
        }

        public ShoppingCart GetCart()
        {
            ShoppingCart cart;
            string cartJson = _session.GetString("cart");

            if (!string.IsNullOrEmpty(cartJson))
            {
                cart = _session.GetObjectFromJson<ShoppingCart>("cart");
            }
            else
            {
                cart = new ShoppingCart();
                _session.SetObjectAsJson("cart", cart);
            }

            return cart;
        }


        public void SaveCart(ShoppingCart cart)
        {
            _session.SetObjectAsJson("cart", cart);
            ShoppingCart test = GetCart();
        }

        public void AddItemToCart(int id, Size size)
        {
            ShoppingCart cart = GetCart();
            Pizza pizza = _pizzaService.GetById(id);

            CartLine line = new CartLine { Pizza = pizza, PizzaSize = size};
            cart.CartLines.Add(line);
            SaveCart(cart);
        }

        public CartViewModel GetCartViewModel()
        {
            ShoppingCart cart = GetCart();
            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.TotalPrice = 0;
            foreach (CartLine item in cart.CartLines)
            {
                switch (item.PizzaSize)
                {
                    case Size.Small:
                        item.SubtotalPrice = $"€{item.Pizza.Price} x 1 = €{item.Pizza.Price} (Base price x size multiplier)";
                        item.SubtotalTotal = $"€{item.Pizza.Price} + €{item.ExtraToppings.Count() * 1} = €{(item.ExtraToppings.Count() * 1) + item.Pizza.Price} (Size price + extra toppings)";
                        item.TotalPriceCartLine = (item.ExtraToppings.Count() * 1) + (item.Pizza.Price);
                        cartViewModel.TotalPrice += (item.ExtraToppings.Count() * 1) + (item.Pizza.Price);
                        break;
                    case Size.Medium:
                        item.SubtotalPrice = $"€{item.Pizza.Price} x 1,2 = €{item.Pizza.Price * 1.2} (Base price x size multiplier)";
                        item.SubtotalTotal = $"€{item.Pizza.Price * 1.2} + €{item.ExtraToppings.Count() * 1} = €{(item.ExtraToppings.Count() * 1) + (item.Pizza.Price * 1.2)} (Size price + extra toppings)";
                        item.TotalPriceCartLine = (item.ExtraToppings.Count() * 1) + (item.Pizza.Price * 1.2);
                        cartViewModel.TotalPrice += (item.ExtraToppings.Count() * 1) + (item.Pizza.Price * 1.2);
                        break;
                    case Size.Large:
                        item.SubtotalPrice = $"€{item.Pizza.Price} x 1,5 = €{item.Pizza.Price * 1.5} (Base price x size multiplier)";
                        item.SubtotalTotal = $"€{item.Pizza.Price * 1.5} + €{item.ExtraToppings.Count() * 1} = €{(item.ExtraToppings.Count() * 1) + (item.Pizza.Price * 1.5)} (Size price + extra toppings)";
                        item.TotalPriceCartLine = (item.ExtraToppings.Count() * 1) + (item.Pizza.Price * 1.5);
                        cartViewModel.TotalPrice += (item.ExtraToppings.Count() * 1) + (item.Pizza.Price * 1.5);
                        break;
                }
                item.SubtotalExtraToppings = $"€1 x {item.ExtraToppings.Count()}  = € {item.ExtraToppings.Count() * 1} (€ 1 x Extra toppings)";
                cartViewModel.CartLines.Add(item);

            }

            return cartViewModel;
        }

        public CartLine GetCartLineById(int id)
        {
            ShoppingCart cart = GetCart();
            CartLine cartLine = cart.CartLines.FirstOrDefault(cl => cl.CartLineId == id);
            return cartLine;
        }

        public void ClearCart()
        {
            ShoppingCart cart = GetCart();
            cart.CartLines = new List<CartLine>();
            SaveCart(cart);
        }
    }
}
