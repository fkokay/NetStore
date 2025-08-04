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
    public class LogoCustomerReader : IErpCustomerReader
    {
        private readonly string _connectionString;

        public LogoCustomerReader(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Logo") ?? throw new Exception("ConnectionStrings ayarlanmadı"); ;
        }
        public async Task<List<ErpCustomerDto>> GetCustomersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT * FROM LG_001_CLCARD";

            var products = await connection.QueryAsync<ErpCustomerDto>(sql);

            return products.ToList();
        }

        public async Task<ErpCustomerBalanceDto?> GetErpCustomerBalanceAsync(string customerCode)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT * FROM LG_001_CLCARD";

            var customerBalance = await connection.QueryFirstOrDefaultAsync<ErpCustomerBalanceDto>(sql);

            return customerBalance;
        }
    }
}
