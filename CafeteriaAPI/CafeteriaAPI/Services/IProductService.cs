using CafeteriaAPI.Models;
using CafeteriaAPI.Models.Requests;

namespace CafeteriaAPI.Services
{
    public interface IProductService
    {
        Task<Product> EditProductStock(EditProductStockRequest request);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int value);
        Task<Invoice> SellProducts(Sale sale);
    }
}
