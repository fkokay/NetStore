using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetStore.Application.DTOs;
using NetStore.Application.Interfaces.Repositories;
using NetStore.Domain.Entities;

namespace NetStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return NotFound();

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var orders = await _orderRepository.GetAllAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, orderDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(Guid id, [FromBody] OrderDto orderDto)
        {
            if (id != orderDto.Id) return BadRequest();

            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null) return NotFound();

            _mapper.Map(orderDto, existingOrder);
            await _orderRepository.UpdateAsync(existingOrder);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null) return NotFound();

            await _orderRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}