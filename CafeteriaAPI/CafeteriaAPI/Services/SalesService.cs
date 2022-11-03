using CafeteriaAPI.Models;
using CafeteriaAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaAPI.Services
{
    public class SalesService : ISalesService
    {
        private readonly IProductService _productService;
        private readonly ICashierService _cashierService;

        public SalesService(IProductService productService, ICashierService cashierService)
        {
            _productService = productService;
            _cashierService = cashierService;
        }

        public async Task<Invoice> CreateSale(CreateSaleRequest request)
        {
            var total = await _productService.SellProductsAndGetTotalPrice(request.Sale);
            
            var invoice = _cashierService.CreateInvoice(request.Sale, total);

            return invoice;
        }
    }
}
