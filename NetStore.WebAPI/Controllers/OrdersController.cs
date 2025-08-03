using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetStore.Application.DTOs.Orders;
using NetStore.Application.Interfaces.Repositories;
using NetStore.Application.Interfaces.Services;
using NetStore.Application.Queries.Orders;
using NetStore.Domain.Entities;

namespace NetStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/orders/{id}
        [HttpGet]
        public async Task<IActionResult> GetOrders(int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetOrdersQuery { PageNumber = pageNumber, PageSize = pageSize };
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);
            var order = await _mediator.Send(query);
            if (order == null) return NotFound();
            return Ok(order);
        }

        //// POST: api/orders
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] OrderDto createOrderDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);


        //    var newOrderId = await _orderService.CreateOrderAsync(createOrderDto);
        //    return CreatedAtAction(nameof(GetById), new { id = newOrderId }, null);
        //}

        //// PUT: api/orders/{id}
        //[HttpPut("{Guid:int}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] OrderDto updateOrderDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var updated = await _orderService.UpdateOrderAsync(id, updateOrderDto);
        //    if (!updated)
        //        return NotFound();

        //    return NoContent();
        //}

        //// DELETE: api/orders/{id}
        //[HttpDelete("{id:Guid}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var deleted = await _orderService.DeleteOrderAsync(id);
        //    if (!deleted)
        //        return NotFound();

        //    return NoContent();
        //}
    }
}