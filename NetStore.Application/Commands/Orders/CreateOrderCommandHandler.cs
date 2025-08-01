using MediatR;
using NetStore.Application.DTOs.Orders;
using NetStore.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Commands.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // İş kuralları, validasyonlar servis içinde
            var createOrderDto = new CreateOrderDto
            {
                CustomerId = request.CustomerId,
                Items = request.Items
                // Diğer alanlar map edilecek
            };

            return await _orderService.CreateOrderAsync(createOrderDto);
        }
    }
}
