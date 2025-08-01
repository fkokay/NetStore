using NetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(Guid orderId);
        Task<Guid> CreateOrderAsync(OrderDto createOrderDto);
        Task<bool> UpdateOrderAsync(Guid orderId, OrderDto updateOrderDto);
        Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
