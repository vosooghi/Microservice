namespace ApiGateway.Orders.Models
{
    //This class should be in its own service.
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
    }
}
