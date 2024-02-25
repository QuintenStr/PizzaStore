using PizzaStore.Data;

namespace PizzaStore.Models
{
    public class StaffViewModel
    {
        public List<PickupOrder>? PickupOrders { get; set; }
        public List<DeliveryOrder>? DeliveryOrders { get; set; }
    }
}
