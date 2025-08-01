using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.DTOs.Orders
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId zorunludur.");
            RuleFor(x => x.OrderDate).LessThanOrEqualTo(DateTime.Now).WithMessage("OrderDate gelecekte olamaz.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("TotalAmount sıfırdan büyük olmalı.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status zorunludur.");

            RuleForEach(x => x.Items).SetValidator(new OrderItemDtoValidator());
        }
    }
}
