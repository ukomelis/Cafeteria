namespace CafeteriaAPI.Models
{
    public class Invoice
    {
        public decimal Total { get; set; }
        public decimal MoneyPaid { get; set; }
        public Change Change { get; set; }

        public Sale Sale { get; set; }
    }
}
