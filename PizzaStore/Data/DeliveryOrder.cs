namespace PizzaStore.Data
{
    public class DeliveryOrder
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public DeliveryStatus Status { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<OrderLine>? OrderLines { get; set; }
    }
}
