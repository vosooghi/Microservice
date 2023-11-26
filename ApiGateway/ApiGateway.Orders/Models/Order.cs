namespace ApiGateway.Orders.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public long PersonId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public long TotalPrice { get; set; }
    }
}
