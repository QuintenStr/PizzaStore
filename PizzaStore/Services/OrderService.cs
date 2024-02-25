using LinqKit;
using Microsoft.AspNetCore.Identity;
using PizzaStore.Data;
using PizzaStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PizzaStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IIngredientService _ingredientService;
        private readonly ApplicationDbContext _context;
        private readonly IPizzaService _pizzaService;

        public OrderService(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IShoppingCartService shoppingCartService,
            IIngredientService ingredientService,
            ApplicationDbContext context,
            IPizzaService pizzaService)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _shoppingCartService = shoppingCartService;
            _ingredientService = ingredientService;
            _context = context;
            _pizzaService = pizzaService;
        }

        public int AddPickup(OrderPickupCreateViewModel model)
        {
            ShoppingCart cart = _shoppingCartService.GetCart();
            List<OrderLine> orderlines = new List<OrderLine>();
            CartViewModel cvm = _shoppingCartService.GetCartViewModel();
            int OrderId = 0;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (CartLine item in cvm.CartLines)
                {
                    List<Ingredient> ingredients = _ingredientService.GetAllIngredients()
                        .Where(i => item.ExtraToppings.Select(e => e.IngredientId).Contains(i.IngredientId))
                        .ToList();

                    OrderLine orderLine = new OrderLine()
                    {
                        PizzaId = item.Pizza.PizzaId,
                        PizzaSize = item.PizzaSize,
                        ExtraToppings = ingredients,
                        Price = item.TotalPriceCartLine,
                    };

                    orderlines.Add(orderLine);
                }

                PickupOrder order = new PickupOrder()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PickupDateTime = model.PickupTime,
                    Status = PickupStatus.Ordered,
                    UserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User),
                    OrderLines = orderlines,
                    TotalPrice = cvm.CartLines.Sum(item => item.TotalPriceCartLine)
                };

                _context.Add(order);
                _context.SaveChanges();
                _shoppingCartService.ClearCart();
                OrderId = order.OrderId;
            }
            return OrderId;
        }

        public int AddDelivery(OrderDeliveryCreateViewModel model)
        {
            ShoppingCart cart = _shoppingCartService.GetCart();
            List<OrderLine> orderlines = new List<OrderLine>();
            CartViewModel cvm = _shoppingCartService.GetCartViewModel();
            int OrderId = 0;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (CartLine item in cvm.CartLines)
                {
                    List<Ingredient> ingredients = _ingredientService.GetAllIngredients()
                        .Where(i => item.ExtraToppings.Select(e => e.IngredientId).Contains(i.IngredientId))
                        .ToList();

                    OrderLine orderLine = new OrderLine()
                    {
                        PizzaId = item.Pizza.PizzaId,
                        PizzaSize = item.PizzaSize,
                        ExtraToppings = ingredients,
                        Price = item.TotalPriceCartLine,
                    };

                    orderlines.Add(orderLine);
                }

                DeliveryOrder order = new DeliveryOrder()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Street = model.Street,
                    Number = model.Number,
                    City = model.City,
                    Zip = model.Zip,
                    Status = DeliveryStatus.Ordered,
                    UserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User),
                    OrderLines = orderlines,
                    TotalPrice = cvm.CartLines.Sum(item => item.TotalPriceCartLine)
                };

                _context.Add(order);
                _context.SaveChanges();
                _shoppingCartService.ClearCart();
                OrderId = order.OrderId;
            }
            return OrderId;
        }

        public PickupOrder GetPickupOrderById(int id)
        {
            List<OrderLine> orderlines = _context.OrderLines.Where(y => y.PickupOrderFK == id).ToList();
            PickupOrder pickupOrder = _context.PickupOrders.SingleOrDefault(x => x.OrderId == id);
            pickupOrder.OrderLines = orderlines;
            return pickupOrder;
        }

        public DeliveryOrder GetDeliveryOrderById(int id)
        {
            List<OrderLine> orderlines = _context.OrderLines.Where(y => y.PickupOrderFK == id).ToList();
            DeliveryOrder deliveryOrder = _context.DeliveryOrders.SingleOrDefault(x => x.OrderId == id);
            deliveryOrder.OrderLines = orderlines;
            return deliveryOrder;
        }

        public void UpdatePickupStatus(PickupOrderViewModel pickupOrderViewModel)
        {
            PickupOrder pickupOrder = _context.PickupOrders.SingleOrDefault(z => z.OrderId == pickupOrderViewModel.Id);
            pickupOrder.Status = pickupOrderViewModel.Status;
            _context.Update(pickupOrder);
            _context.SaveChanges();
        }

        public void UpdateDeliveryStatus(DeliveryOrderViewModel deliveryOrderViewModel)
        {
            DeliveryOrder deliveryOrder = _context.DeliveryOrders.SingleOrDefault(z => z.OrderId == deliveryOrderViewModel.Id);
            deliveryOrder.Status = deliveryOrderViewModel.Status;
            _context.Update(deliveryOrder);
            _context.SaveChanges();
        }

        public List<PickupOrder> GetPickupOrdersToBeMade()
        {
            return _context.PickupOrders.Where(x => x.Status != PickupStatus.Collected).ToList();
        }

        public List<DeliveryOrder> GetDeliveryOrdersToBeMade()
        {
            return _context.DeliveryOrders.Where(x => x.Status != DeliveryStatus.Delivered).ToList();
        }

        public List<OrderLine> GetPickupOrderLines(int id)
        {
            var orderLines = _context.OrderLines.Where(y => y.PickupOrderFK == id).ToList();

            foreach (var orderLine in orderLines)
            {
                _context.Entry(orderLine).Reference(x => x.Pizza).Load();
                _context.Entry(orderLine).Collection(x => x.ExtraToppings).Load();
            }

            return orderLines;
        }

        public List<OrderLine> GetDeliveryOrderLines(int id)
        {
            var orderLines = _context.OrderLines.Where(y => y.DeliveryOrderFK == id).ToList();

            foreach (var orderLine in orderLines)
            {
                _context.Entry(orderLine).Reference(x => x.Pizza).Load();
                _context.Entry(orderLine).Collection(x => x.ExtraToppings).Load();
            }

            return orderLines;
        }
    }
}
