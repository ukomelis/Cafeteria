using CafeteriaAPI.Models;
using CafeteriaAPI.Models.Requests;

namespace CafeteriaAPI.Services
{
    public interface ISalesService
    {
        Task<Invoice> CreateSale(CreateSaleRequest request);
    }
}
