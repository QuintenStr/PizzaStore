using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using PizzaStore.Data;
using PizzaStore.Models;
using PizzaStore.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authService;

        public OrderController(
            IShoppingCartService shoppingCartService,
            UserManager<ApplicationUser> userManager,
            IOrderService orderService,
            IAuthorizationService authService)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _orderService = orderService;
            _authService = authService;
        }

        [Authorize(Policy = "MinRankCustomer")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "MinRankCustomer")]
        public async Task<IActionResult> AddPickupAsync()
        {
            var model = new OrderPickupCreateViewModel
            {
                ShoppingCart = _shoppingCartService.GetCart()
            };

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.PickupTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).Add(new TimeSpan(0, 15, 0));

                foreach (var item in model.ShoppingCart.CartLines)
                {
                    var cartLine = _shoppingCartService.GetCartViewModel().CartLines.FirstOrDefault(cl => cl.CartLineId == item.CartLineId);
                    if (cartLine != null)
                    {
                        item.TotalPriceCartLine = cartLine.TotalPriceCartLine;
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MinRankCustomer")]
        public async Task<IActionResult> AddPickupAsync(OrderPickupCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                int newlymadeid = _orderService.AddPickup(model);
                return Redirect($"PickupDetails/{newlymadeid}");
            }

            model.ShoppingCart = _shoppingCartService.GetCart();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.PickupTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 15, 0));

                foreach (var item in model.ShoppingCart.CartLines)
                {
                    var cartLine = _shoppingCartService.GetCartViewModel().CartLines.FirstOrDefault(cl => cl.CartLineId == item.CartLineId);
                    if (cartLine != null)
                    {
                        item.TotalPriceCartLine = cartLine.TotalPriceCartLine;
                    }
                }
            }

            return View(model);
        }

        [Authorize(Policy = "MinRankCustomer")]
        public async Task<IActionResult> AddDeliveryAsync()
        {
            var model = new OrderDeliveryCreateViewModel
            {
                ShoppingCart = _shoppingCartService.GetCart()
            };

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;

                foreach (var item in model.ShoppingCart.CartLines)
                {
                    var cartLine = _shoppingCartService.GetCartViewModel().CartLines.FirstOrDefault(cl => cl.CartLineId == item.CartLineId);
                    if (cartLine != null)
                    {
                        item.TotalPriceCartLine = cartLine.TotalPriceCartLine;
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MinRankCustomer")]
        public async Task<IActionResult> AddDeliveryAsync(OrderDeliveryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                int newlymadeid = _orderService.AddDelivery(model);
                return Redirect($"DeliveryDetails/{newlymadeid}");
            }

            model.ShoppingCart = _shoppingCartService.GetCart();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;

                foreach (var item in model.ShoppingCart.CartLines)
                {
                    var cartLine = _shoppingCartService.GetCartViewModel().CartLines.FirstOrDefault(cl => cl.CartLineId == item.CartLineId);
                    if (cartLine != null)
                    {
                        item.TotalPriceCartLine = cartLine.TotalPriceCartLine;
                    }
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> PickupDetailsAsync(int id)
        {
            PickupOrder pickupOrder = _orderService.GetPickupOrderById(id);

            var authResult = await _authService.AuthorizeAsync(User, pickupOrder, "PickupOrderOwnerOrStaffOrOwner");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            IEnumerable<SelectListItem> statusValues = Enum.GetValues(typeof(PickupStatus)).Cast<PickupStatus>().Select(v => new SelectListItem { Text = v.ToString(), Value = ((int)v).ToString() });
            SelectList statusList = new SelectList(statusValues, "Value", "Text");
            ViewBag.StatusList = statusList;
            PickupOrderViewModel pickupOrderViewModel = new PickupOrderViewModel()
            {
                FirstName = pickupOrder.FirstName,
                LastName = pickupOrder.LastName,
                Status = pickupOrder.Status,
                PickupTime = pickupOrder.PickupDateTime,
                Id = pickupOrder.OrderId,
                OrderLines = _orderService.GetPickupOrderLines(pickupOrder.OrderId)
            };
            return View(pickupOrderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> PickupDetailsAsync(PickupOrderViewModel pickupOrderViewModel)
        {
            PickupOrder pickupOrder = _orderService.GetPickupOrderById(pickupOrderViewModel.Id);

            var authResult = await _authService.AuthorizeAsync(User, pickupOrder, "PickupOrderOwnerOrStaffOrOwner");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            if (ModelState.IsValid)
            {
                _orderService.UpdatePickupStatus(pickupOrderViewModel);
                return Redirect($"{pickupOrderViewModel.Id}");
            }

            pickupOrderViewModel.FirstName = pickupOrder.FirstName;
            pickupOrderViewModel.LastName = pickupOrder.LastName;
            pickupOrderViewModel.Status = pickupOrder.Status;
            pickupOrderViewModel.PickupTime = pickupOrder.PickupDateTime;
            pickupOrderViewModel.OrderLines = _orderService.GetPickupOrderLines(pickupOrder.OrderId);
            IEnumerable<SelectListItem> statusValues = Enum.GetValues(typeof(PickupStatus)).Cast<PickupStatus>().Select(v => new SelectListItem { Text = v.ToString(), Value = ((int)v).ToString() });
            SelectList statusList = new SelectList(statusValues, "Value", "Text");
            ViewBag.StatusList = statusList;
            return View(pickupOrderViewModel);
        }

        [Authorize]
        public async Task<IActionResult> DeliveryDetailsAsync(int id)
        {
            DeliveryOrder deliveryOrder = _orderService.GetDeliveryOrderById(id);

            var authResult = await _authService.AuthorizeAsync(User, deliveryOrder, "DeliveryOrderOwnerOrStaffOrOwner");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            IEnumerable<SelectListItem> statusValues = Enum.GetValues(typeof(DeliveryStatus)).Cast<DeliveryStatus>().Select(v => new SelectListItem { Text = v.ToString(), Value = ((int)v).ToString() });
            SelectList statusList = new SelectList(statusValues, "Value", "Text");
            ViewBag.StatusList = statusList;
            DeliveryOrderViewModel deliveryOrderViewModel = new DeliveryOrderViewModel()
            {
                FirstName = deliveryOrder.FirstName,
                LastName = deliveryOrder.LastName,
                Status = deliveryOrder.Status,
                Street = deliveryOrder.Street,
                Number = deliveryOrder.Number,
                City = deliveryOrder.City,
                Zip = deliveryOrder.Zip,
                Id = deliveryOrder.OrderId,
                OrderLines = _orderService.GetDeliveryOrderLines(deliveryOrder.OrderId)
            };

            return View(deliveryOrderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeliveryDetailsAsync(DeliveryOrderViewModel deliveryOrderViewModel)
        {
            DeliveryOrder deliveryOrder = _orderService.GetDeliveryOrderById(deliveryOrderViewModel.Id);

            var authResult = await _authService.AuthorizeAsync(User, deliveryOrder, "DeliveryOrderOwnerOrStaffOrOwner");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            if (ModelState.IsValid)
            {
                _orderService.UpdateDeliveryStatus(deliveryOrderViewModel);
                return Redirect($"{deliveryOrderViewModel.Id}");
            }

            deliveryOrderViewModel.FirstName = deliveryOrder.FirstName;
            deliveryOrderViewModel.LastName = deliveryOrder.LastName;
            deliveryOrderViewModel.Status = deliveryOrder.Status;
            deliveryOrderViewModel.Street = deliveryOrder.Street;
            deliveryOrderViewModel.Number = deliveryOrder.Number;
            deliveryOrderViewModel.City = deliveryOrder.City;
            deliveryOrderViewModel.Zip = deliveryOrder.Zip;
            deliveryOrderViewModel.OrderLines = _orderService.GetDeliveryOrderLines(deliveryOrder.OrderId);
            IEnumerable<SelectListItem> statusValues = Enum.GetValues(typeof(DeliveryStatus)).Cast<DeliveryStatus>().Select(v => new SelectListItem { Text = v.ToString(), Value = ((int)v).ToString() });
            SelectList statusList = new SelectList(statusValues, "Value", "Text");
            ViewBag.StatusList = statusList;
            return View(deliveryOrderViewModel);
        }

    }
}
