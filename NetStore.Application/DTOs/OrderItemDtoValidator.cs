using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.DTOs
{
    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId zorunludur.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity sıfırdan büyük olmalı.");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("UnitPrice sıfırdan büyük olmalı.");
        }
    }
}
