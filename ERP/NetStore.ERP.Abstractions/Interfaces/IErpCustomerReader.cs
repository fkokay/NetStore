using NetStore.ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.Abstractions.Interfaces
{
    public interface IErpCustomerReader
    {
        Task<List<ErpCustomerDto>> GetCustomersAsync();
        Task<ErpCustomerBalanceDto?> GetErpCustomerBalanceAsync(string customerCode);
    }
}
