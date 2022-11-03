namespace CafeteriaAPI.Models
{
    public class Sale
    {
        public IEnumerable<ProductOrder> ProductOrders { get; set; }

        public decimal MoneyPaid { get; set; }
    }
}
