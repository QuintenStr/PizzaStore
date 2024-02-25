namespace PizzaStore.Data
{
    public class PickupOrder
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan PickupDateTime { get; set; }
        public PickupStatus Status { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<OrderLine>? OrderLines { get; set; }
    }
}
