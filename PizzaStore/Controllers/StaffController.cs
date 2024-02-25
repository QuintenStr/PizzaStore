using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Models;
using PizzaStore.Services;

namespace PizzaStore.Controllers
{
    public class StaffController : Controller
    {
        private IOrderService _orderService;

        public StaffController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [Authorize(Policy = "MinRankStaff")]
        public IActionResult Index()
        {
            StaffViewModel model= new StaffViewModel();
            model.PickupOrders = _orderService.GetPickupOrdersToBeMade();
            model.DeliveryOrders = _orderService.GetDeliveryOrdersToBeMade();
            return View(model);
        }
    }
}
