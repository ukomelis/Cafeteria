namespace CafeteriaAPI.Models.Requests
{
    public class EditProductStockRequest
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }        
    }
}