using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data;
using PizzaStore.Models;
using PizzaStore.Services;

namespace PizzaStore.Controllers
{
    public class CartController : Controller
    {
        private IShoppingCartService _shoppingCartService;
        private IIngredientService _ingredientService;

        public CartController(IShoppingCartService shoppingCartService, IIngredientService ingredientService)
        {
            _shoppingCartService = shoppingCartService;
            _ingredientService = ingredientService;
        }

        public IActionResult Index()
        {
            CartViewModel cartViewModel = _shoppingCartService.GetCartViewModel();
            return View(cartViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int id, Size size)
        {
            _shoppingCartService.AddItemToCart(id, size);
            return Redirect("/Cart/Index");
        }

        public IActionResult EditToppings(int id, ExtraToppingsSearchViewModel extraToppingsSearchViewModel)
        {
            extraToppingsSearchViewModel.cartLine = _shoppingCartService.GetCartLineById(id);
            extraToppingsSearchViewModel.Ingredients = _ingredientService.SearchIngredients(extraToppingsSearchViewModel.SearchByName);

            return View(extraToppingsSearchViewModel);
        }

        public IActionResult ResetSearchEditToppings(int id)
        {
            ExtraToppingsSearchViewModel extraToppingsSearchViewModel = new ExtraToppingsSearchViewModel();
            var routeValues = new { id = id, extraToppingsSearchViewModel = extraToppingsSearchViewModel };
            return RedirectToAction($"EditToppings", routeValues);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditToppings(ExtraToppingsSearchViewModel extraToppingsSearchViewModel)
        {
            return View(extraToppingsSearchViewModel);
        }

        public IActionResult AddTopping(int ingrid, int cartlineid) {
            ShoppingCart cart = _shoppingCartService.GetCart();
            CartLine edittingCartLine = cart.CartLines.Where(x => x.CartLineId == cartlineid).FirstOrDefault();
            Ingredient ingr = _ingredientService.GetById(ingrid);
            IngredientExtraToppingCartLineItem item = new IngredientExtraToppingCartLineItem();
            item.Name = ingr.Name;
            item.Description = ingr.Description;
            item.ImageUrl= ingr.ImageUrl;
            item.IngredientId = ingr.IngredientId;
            edittingCartLine.ExtraToppings.Add(item);
            _shoppingCartService.SaveCart(cart);
            return Redirect($"/Cart/EditToppings/{cartlineid}");
        }

        public IActionResult RemoveFromCart(int cartlineid)
        {
            ShoppingCart cart = _shoppingCartService.GetCart();
            cart.CartLines.RemoveAll(x => x.CartLineId == cartlineid);
            _shoppingCartService.SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTopping(int cartlineid, int extratoppingid) {
            ShoppingCart cart = _shoppingCartService.GetCart();
            CartLine edittingCartLine = cart.CartLines.Where(x => x.CartLineId == cartlineid).FirstOrDefault();
            if (edittingCartLine != null)
            {
                edittingCartLine.ExtraToppings.RemoveAll(item => item.Id == extratoppingid);
            }
            _shoppingCartService.SaveCart(cart);
            return Redirect($"/Cart/EditToppings/{cartlineid}");
        }

        public IActionResult ClearCart()
        {
            _shoppingCartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
