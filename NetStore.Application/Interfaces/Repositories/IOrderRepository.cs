using NetStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int pageSize);
        Task<Order> GetOrderByIdAsync(Guid orderId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Order order);
        Task<List<Order>> GetAllAsync();
    }
}
