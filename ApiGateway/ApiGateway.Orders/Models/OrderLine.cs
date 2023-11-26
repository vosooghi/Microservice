namespace ApiGateway.Orders.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
    }
}
