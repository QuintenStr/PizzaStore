using PizzaStore.Data;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public interface IOrderService
    {
        public int AddPickup(OrderPickupCreateViewModel model);
        public int AddDelivery(OrderDeliveryCreateViewModel model);
        public PickupOrder GetPickupOrderById(int id);
        public DeliveryOrder GetDeliveryOrderById(int id);
        public void UpdatePickupStatus(PickupOrderViewModel pickupOrderViewModel);
        public void UpdateDeliveryStatus(DeliveryOrderViewModel deliveryOrderViewModel);
        public List<DeliveryOrder> GetDeliveryOrdersToBeMade();
        public List<PickupOrder> GetPickupOrdersToBeMade();
        public List<OrderLine> GetPickupOrderLines(int id);
        public List<OrderLine> GetDeliveryOrderLines(int id);
    }
}