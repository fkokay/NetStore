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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _logoProductReader.GetProductsAsync();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            var product = await _logoProductReader.GetProductByCodeAsync(code);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPrices()
        {
            var prices = await _logoProductReader.GetProductPriceAsync();
            if (prices == null) return NotFound();
            return Ok(prices);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductStocks()
        {
            var stocks = await _logoProductReader.GetProductStockAsync();
            if (stocks == null) return NotFound();
            return Ok(stocks);

        }
    }
}
