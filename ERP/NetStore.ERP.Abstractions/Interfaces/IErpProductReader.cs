using NetStore.ERP.SharedKernel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.Abstractions.Interfaces
{
    public interface IErpProductReader
    {
        Task<List<ErpProductDto>> GetProductsAsync();
        Task<ErpProductDto?> GetProductByCodeAsync(string productCode);
    }
}
