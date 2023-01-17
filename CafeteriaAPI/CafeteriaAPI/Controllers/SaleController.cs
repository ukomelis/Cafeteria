using CafeteriaAPI.Exceptions;
using CafeteriaAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CafeteriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISalesService _salesService;
        public SaleController(ILogger<SaleController> logger, ISalesService salesService)
        {
            _logger = logger;
            _salesService = salesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var invoice = await _salesService.CreateSale(request);       

                return Ok(invoice);
            }
            catch (OutOfStockException ex)
            {
                {
                    _logger.LogError(ex.Message);
                    return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating a sale");
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }            
        }
    }
}