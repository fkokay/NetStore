using MediatR;
using NetStore.Application.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Queries.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
