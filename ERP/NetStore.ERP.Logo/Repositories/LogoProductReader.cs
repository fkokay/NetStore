using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetStore.ERP.Abstractions.Interfaces;
using NetStore.ERP.Application.DTOs;
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

            var sql = @"
                SELECT
                    ITEMS.CODE AS Code,
                    ITEMS.NAME as Name
                FROM
                    LG_001_ITEMS AS ITEMS WITH(NOLOCK)
                WHERE
                    (ITEMS.ACTIVE = 0) AND (ITEMS.CARDTYPE NOT IN(4, 20, 21))";

            var products = await connection.QueryAsync<ErpProductDto>(sql);

            return products.ToList();
        }
        public async Task<ErpProductDto?> GetProductByCodeAsync(string productCode)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT
                    ITEMS.CODE AS Code,
                    ITEMS.NAME as Name
                FROM
                    LG_001_ITEMS AS ITEMS WITH(NOLOCK)
                WHERE
                    CODE = @Code
                    AND (ITEMS.ACTIVE = 0) AND (ITEMS.CARDTYPE NOT IN(4, 20, 21))";

            var product = await connection.QueryFirstOrDefaultAsync<ErpProductDto>(sql, new { Code = productCode });

            return product;
        }
        public async Task<List<ErpProductPriceDto>> GetProductPriceAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT
                    ITEMS.CODE AS Code,
                    PRCLIST.PRICE AS Price
                FROM
                    LG_001_ITEMS AS ITEMS WITH(NOLOCK)
                INNER JOIN
                    LG_001_PRCLIST AS PRCLIST WITH(NOLOCK) ON ITEMS.LOGICALREF = PRCLIST.CARDREF
                WHERE
                    (ITEMS.ACTIVE = 0) AND (ITEMS.CARDTYPE NOT IN(4, 20, 21))
                    AND PRCLIST.PTYPE = 2
                    AND(PRCLIST.BEGDATE IS NULL OR PRCLIST.BEGDATE <= GETDATE())
                    AND(PRCLIST.ENDDATE IS NULL OR PRCLIST.ENDDATE >= GETDATE())
            ";

            var prices = await connection.QueryAsync<ErpProductPriceDto>(sql);

            return prices.ToList();
        }
        public async Task<List<ErpProductStockDto>> GetProductStockAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var sql = @"
                SELECT
                    ITEMS.CODE AS ProductCode,
                    ISNULL(SUM(GNTOTST.ONHAND - GNTOTST.RESERVED), 0) AS Stock
                FROM
                    LG_001_ITEMS AS ITEMS WITH(NOLOCK)
                INNER JOIN
                    LV_001_01_GNTOTST AS GNTOTST WITH(NOLOCK) ON GNTOTST.STOCKREF = ITEMS.LOGICALREF
                WHERE
                    (ITEMS.ACTIVE = 0) AND (ITEMS.CARDTYPE NOT IN(4, 20, 21))
                    AND GNTOTST.INVENNO = -1
                GROUP BY
                    ITEMS.CODE
            ";

            var stocks = await connection.QueryAsync<ErpProductStockDto>(sql);

            return stocks.ToList();
        }
    }
}
