using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetStore.ERP.Abstractions.Interfaces;
using NetStore.ERP.SharedKernel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.Logo.Repositories
{
    public class LogoProductReader : IErpProductReader
    {
        private readonly string _connectionString;

        public LogoProductReader(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Logo") ?? throw new Exception("ConnectionStrings ayarlanmadı"); ;
        }

        public async Task<List<ErpProductDto>> GetProductsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = "SELECT CODE AS Code,NAME as Name FROM LG_001_ITEMS";

            var products = await connection.QueryAsync<ErpProductDto>(sql);

            return products.ToList();
        }
        public async Task<ErpProductDto?> GetProductByCodeAsync(string productCode)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = "SELECT CODE AS Code,NAME as Name FROM LG_001_ITEMS";

            var product = await connection.QueryFirstOrDefaultAsync<ErpProductDto>(sql);

            return product;
        }
        public async Task<List<ErpProductPriceDto>> GetProductPriceAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = "SELECT CODE AS Code,NAME as Name FROM LG_001_ITEMS";

            var products = await connection.QueryAsync<ErpProductPriceDto>(sql);

            return products.ToList();
        }
        public async Task<List<ErpProductStockDto>> GetProductStockAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = "SELECT CODE AS Code,NAME as Name FROM LG_001_ITEMS";

            var products = await connection.QueryAsync<ErpProductStockDto>(sql);

            return products.ToList();
        }
    }
}
