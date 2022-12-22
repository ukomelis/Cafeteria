using CafeteriaAPI.Models.Enums;
using CafeteriaAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CafeteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting product");
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();

                if (products == null)

                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting products");
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] EditProductStockRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            try
            {                
                var product = await _productService.EditProductStock(request);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing product");
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }         
    }
}
