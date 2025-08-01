using AutoMapper;
using NetStore.Application.DTOs;
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

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<Guid> CreateOrderAsync(OrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            await _orderRepository.AddAsync(order);
            return order.Id;
        }

        public async Task<bool> UpdateOrderAsync(Guid orderId, OrderDto updateOrderDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId);
            if (existingOrder == null) return false;

            _mapper.Map(updateOrderDto, existingOrder);
            await _orderRepository.UpdateAsync(existingOrder);
            return true;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            await _orderRepository.DeleteAsync(order);
            return true;
        }
    }
}
