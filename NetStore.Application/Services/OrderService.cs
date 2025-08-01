using AutoMapper;
using NetStore.Application.DTOs.Orders;
using NetStore.Application.Interfaces.Repositories;
using NetStore.Application.Interfaces.Services;
using NetStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            // İş kuralları, validasyonlar burada yapılabilir.

            var order = _mapper.Map<Order>(createOrderDto);
            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.UtcNow;

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return order.Id;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            _orderRepository.Remove(order);
            await _orderRepository.SaveChangesAsync();

            return true;
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _orderRepository.GetOrderWithItemsByIdAsync(orderId);
            if (order == null) return null;

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int pageNumber, int pageSize)
        {
            var orders = await _orderRepository.GetOrdersAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<bool> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await _orderRepository.GetByIdAsync(updateOrderDto.Id);
            if (order == null) return false;

            // Burada güncelleme işlemleri
            _mapper.Map(updateOrderDto, order);

            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();

            return true;
        }
    }
}
