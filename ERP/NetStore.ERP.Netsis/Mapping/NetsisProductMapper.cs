using Microsoft.Data.SqlClient;
using NetStore.ERP.SharedKernel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.Netsis.Mapping
{
    public static class NetsisProductMapper
    {
        public static ErpProductDto MapFromReader(SqlDataReader reader)
        {
            return new ErpProductDto
            {
                Code = reader["STOK_KODU"]?.ToString() ?? string.Empty,
                Name = reader["STOK_ADI"]?.ToString() ?? string.Empty,
                Unit = reader["BIRIM"]?.ToString() ?? string.Empty,
                VatRate = reader["KDV_ORANI"] != DBNull.Value ? Convert.ToDecimal(reader["KDV_ORANI"]) : 0
            };
        }
    }
}
