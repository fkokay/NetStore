using Microsoft.AspNetCore.Mvc;
using NetStore.ERP.Abstractions.Interfaces;
using NetStore.ERP.Logo.Repositories;

namespace NetStore.ERP.WebApi.Controllers
{
    [ApiController]
    [Route("api/logo")]
    public class LogoController : ControllerBase
    {
        private readonly IErpProductReader _erpProductReader;
        private readonly IErpCustomerReader _erpCustomerReader;
        private readonly ILogger<LogoController> _logger;
        public LogoController(IErpProductReader erpProductReader,IErpCustomerReader erpCustomerReader, ILogger<LogoController> logger)
        {
            _erpProductReader = erpProductReader;
            _erpCustomerReader = erpCustomerReader;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _erpProductReader.GetProductsAsync();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("product-by-code/{code}")]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            var product = await _erpProductReader.GetProductByCodeAsync(code);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("product-prices")]
        public async Task<IActionResult> GetProductPrices()
        {
            var prices = await _erpProductReader.GetProductPriceAsync();
            if (prices == null) return NotFound();
            return Ok(prices);
        }

        [HttpGet("product-stocks")]
        public async Task<IActionResult> GetProductStocks()
        {
            var stocks = await _erpProductReader.GetProductStockAsync();
            if (stocks == null) return NotFound();
            return Ok(stocks);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _erpCustomerReader.GetCustomersAsync();
            if (customers == null) return NotFound();

            return Ok(customers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("customer-account-statements/{customerCode}")]
        public async Task<IActionResult> GetCustomerAccountStatement(string customerCode)
        {
            var customerAccountStatements = await _erpCustomerReader.GetErpCustomerAccountStatementAsync(customerCode);
            if (customerAccountStatements == null) return NotFound();

            return Ok(customerAccountStatements);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("customer-balance/{customerCode}")]
        public async Task<IActionResult> GetCustomerBalanceAsync(string customerCode)
        {
            var customerBalance = await _erpCustomerReader.GetErpCustomerBalanceAsync(customerCode);
            if (customerBalance == null) return NotFound();

            return Ok(customerBalance);
        }
    }
}
