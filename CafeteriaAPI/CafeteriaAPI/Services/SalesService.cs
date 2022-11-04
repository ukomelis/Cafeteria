using CafeteriaAPI.Models;
using CafeteriaAPI.Models.Requests;

namespace CafeteriaAPI.Services
{
    public class SalesService : ISalesService
    {
        private readonly IProductService _productService;

        public SalesService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Invoice> CreateSale(CreateSaleRequest request)
        {
            var invoice = await _productService.SellProducts(request.Sale);            

            return invoice;
        }
    }
}