using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetStore.Application.DTOs;
using NetStore.Application.Interfaces.Repositories;
using NetStore.Application.Interfaces.Services;
using NetStore.Domain.Entities;

namespace NetStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newOrderId = await _orderService.CreateOrderAsync(createOrderDto);
            return CreatedAtAction(nameof(GetById), new { id = newOrderId }, null);
        }

        // PUT: api/orders/{id}
        [HttpPut("{Guid:int}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OrderDto updateOrderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _orderService.UpdateOrderAsync(id, updateOrderDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _orderService.DeleteOrderAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}