using CafeteriaAPI.Exceptions;
using CafeteriaAPI.Models;
using CafeteriaAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly CafeteriaContext _context;
        private readonly ICashierService _cashierService;

        public ProductService(CafeteriaContext context, ICashierService cashierService)
        {
            _context = context;
            _cashierService = cashierService;
        }

        public async Task<Product> EditProductStock(EditProductStockRequest request)
        {
            //find product from the db
            var product = await GetProduct(request.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
                
             product.Stock = request.Stock;

            //save changes
            await _context.SaveChangesAsync();

            return product;

        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Select(x => x).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Invoice> SellProducts(Sale sale)
        {
            var total = 0m;

            foreach (var productOrder in sale.ProductOrders)
            {
                //find product from the db
                var product = await GetProduct(productOrder.ProductId);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }

                //check if there is enough stock
                if (product.Stock < 1 || product.Stock < productOrder.Quantity)
                {
                    throw new OutOfStockException($"Not enough stock for product {product.Name}. {product.Stock} left");
                }

                product.Stock -= productOrder.Quantity;
                total = productOrder.Quantity * product.Price;
            }

            if (total > sale.MoneyPaid)
            {
                throw new Exception("Not enough money paid");
            }

            var invoice = _cashierService.CreateInvoice(sale, total);

            //save changes
            await _context.SaveChangesAsync();

            return invoice;
        }
    }
}