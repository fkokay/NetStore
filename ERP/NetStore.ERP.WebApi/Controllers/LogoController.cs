using Microsoft.AspNetCore.Mvc;
using NetStore.ERP.Abstractions.Interfaces;
using NetStore.ERP.Logo.Repositories;

namespace NetStore.ERP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LogoController : ControllerBase
    {
        private readonly IErpProductReader _logoProductReader;
        private readonly ILogger<LogoController> _logger;
        public LogoController(IErpProductReader logoProductReader, ILogger<LogoController> logger)
        {
            _logoProductReader = logoProductReader;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _logoProductReader.GetProductsAsync();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("product-by-code/{code}")]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            var product = await _logoProductReader.GetProductByCodeAsync(code);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("product-prices")]
        public async Task<IActionResult> GetProductPrices()
        {
            var prices = await _logoProductReader.GetProductPriceAsync();
            if (prices == null) return NotFound();
            return Ok(prices);
        }

        [HttpGet("product-stocks")]
        public async Task<IActionResult> GetProductStocks()
        {
            var stocks = await _logoProductReader.GetProductStockAsync();
            if (stocks == null) return NotFound();
            return Ok(stocks);

        }
    }
}
