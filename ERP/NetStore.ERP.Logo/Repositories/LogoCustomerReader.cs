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
        SELECT 
            LOGICALREF AS Id,
            CODE AS Code,
            DEFINITION_ AS Name,
            TRIM(ADDR1+' '+ADDR2) AS Address,
            TAXNR AS TaxNumber,
            TAXOFFICE AS TaxOffice,
            CITY AS City,
            TOWN AS District,
            TELNRS1 AS Phone,
            EMAILADDR AS Email,
            CAPIBLOCK_CREADEDDATE AS CreatedDate,
            CAPIBLOCK_MODIFIEDDATE AS UpdatedDate,
            CASE WHEN ACTIVE = 0 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS IsActive
        FROM LG_001_CLCARD
        WHERE CARDTYPE IN (1, 3)";

            var customers = await connection.QueryAsync<ErpCustomerDto>(sql);
            return customers.ToList();
        }

        public async Task<List<ErpCustomerAccountStatementDto>> GetErpCustomerAccountStatementAsync(string customerCode, DateTime? fromDate = null, DateTime? toDate = null)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT 
                    LGMAIN.DATE_ AS [Date],
                    LGMAIN.DOCODE AS DocumentNo,
                    CASE LGMAIN.TRCODE
                        WHEN 1 THEN 'Nakit Tahsilat'
                        WHEN 2 THEN 'Nakit Ödeme'
                        WHEN 3 THEN 'Borç Dekontu'
                        WHEN 4 THEN 'Alacak Dekontu'
                        WHEN 5 THEN 'Virman Fişi'
                        WHEN 6 THEN 'Kur Farkı Fişi'
                        WHEN 12 THEN 'Özel Fiş'
                        WHEN 14 THEN 'Açılış Fişi'
                        WHEN 31 THEN 'Satınalma Faturası'
                        WHEN 32 THEN 'Perakende Satış İade Faturası'
                        WHEN 33 THEN 'Toptan Satış İade Faturası'
                        WHEN 34 THEN 'Alınan Hizmet Faturası'
                        WHEN 36 THEN 'Satınalma İade Faturası'
                        WHEN 37 THEN 'Perakende Satış Faturası'
                        WHEN 38 THEN 'Toptan Satış Faturası'
                        WHEN 39 THEN 'Verilen Hizmet Faturası'
                        ELSE 'Diğer'
                    END AS TransactionType,
                    LGMAIN.LINEEXP AS Description,
                    CASE WHEN LGMAIN.SIGN = 0 THEN LGMAIN.TRNET ELSE 0 END AS Debit,
                    CASE WHEN LGMAIN.SIGN = 1 THEN LGMAIN.TRNET ELSE 0 END AS Credit
                FROM LG_001_01_CLFLINE AS LGMAIN WITH (NOLOCK)
                INNER JOIN LG_001_CLCARD AS CLCARD WITH (NOLOCK) ON LGMAIN.CLIENTREF = CLCARD.LOGICALREF
                WHERE CLCARD.CODE = @CustomerCode";

            if (fromDate.HasValue)
                sql += " AND LGMAIN.DATE_ >= @FromDate";
            if (toDate.HasValue)
                sql += " AND LGMAIN.DATE_ <= @ToDate";

            sql += " ORDER BY LGMAIN.DATE_ ASC";

            var statementList = await connection.QueryAsync<ErpCustomerAccountStatementDto>(sql, new
            {
                CustomerCode = customerCode,
                FromDate = fromDate,
                ToDate = toDate
            });

            return statementList.ToList();
        }

        public async Task<ErpCustomerBalanceDto?> GetErpCustomerBalanceAsync(string customerCode)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"
                SELECT 
                    CLCARD.CODE AS CustomerNumber,
                    ISNULL((SELECT SUM(GNTOTCL.DEBIT) 
                            FROM LV_001_01_GNTOTCL AS GNTOTCL WITH(NOLOCK) 
                            WHERE CLCARD.LOGICALREF = GNTOTCL.CARDREF 
                            AND GNTOTCL.TOTTYP = 1), 0.00) AS Debit,
                    ISNULL((SELECT SUM(GNTOTCL.CREDIT) 
                            FROM LV_001_01_GNTOTCL AS GNTOTCL WITH(NOLOCK) 
                            WHERE CLCARD.LOGICALREF = GNTOTCL.CARDREF 
                            AND GNTOTCL.TOTTYP = 1), 0.00) AS Credit,
                    ISNULL((SELECT SUM(GNTOTCL.DEBIT - GNTOTCL.CREDIT) 
                            FROM LV_001_01_GNTOTCL AS GNTOTCL WITH(NOLOCK) 
                            WHERE CLCARD.LOGICALREF = GNTOTCL.CARDREF 
                            AND GNTOTCL.TOTTYP = 1), 0.00) AS Balance
                FROM LG_001_CLCARD AS CLCARD
                WHERE CLCARD.CODE = @CustomerCode";

            var customerBalance = await connection.QueryFirstOrDefaultAsync<ErpCustomerBalanceDto>(sql, new { CustomerCode = customerCode });

            return customerBalance;
        }
    }
}
