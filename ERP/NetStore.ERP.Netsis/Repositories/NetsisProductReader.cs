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

namespace NetStore.ERP.Netsis.Repositories
{
    public class NetsisProductReader : IErpProductReader
    {
        private readonly string _connectionString;

        public NetsisProductReader(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Netsis") ?? throw new Exception("ConnectionStrings ayarlanmadı");
        }

        public async Task<List<ErpProductDto>> GetProductsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = "SELECT STOK_KODU AS Code, STOK_ADI AS Name, BIRIM AS Unit, KDV_ORANI AS VatRate, BARCODE, STOK_MIKTARI, GUNCELLEME_TARIHI FROM NETSIS_PRODUCTS";

            var products = await connection.QueryAsync<ErpProductDto>(sql);

            return products.ToList();
        }

        public async Task<ErpProductDto?> GetProductByCodeAsync(string productCode)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = @"SELECT STOK_KODU AS Code, STOK_ADI AS Name, BIRIM AS Unit, KDV_ORANI AS VatRate
                         FROM NETSIS_PRODUCTS
                         WHERE STOK_KODU = @ProductCode";

            return await connection.QueryFirstOrDefaultAsync<ErpProductDto>(sql, new { ProductCode = productCode });
        }

        public Task<List<ErpProductStockDto>> GetProductStockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ErpProductPriceDto>> GetProductPriceAsync()
        {
            throw new NotImplementedException();
        }
    }
}
