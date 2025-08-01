using NetStore.Application.DTOs.Integrations;
using NetStore.Application.Interfaces.Services.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Services.Marketplace
{
    public class TrendyolApiService : ITrendyolApiService
    {
        public Task<IEnumerable<TrendyolOrderDto>> GetOrdersAsync(DateTime? lastSyncDate = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NotifyReturnAsync(TrendyolReturnRequestDto returnDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendProductAsync(TrendyolProductCreateDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductStockAsync(TrendyolProductStockUpdateDto stockUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShipmentAsync(TrendyolShipmentUpdateDto shipmentDto)
        {
            throw new NotImplementedException();
        }
    }
}
