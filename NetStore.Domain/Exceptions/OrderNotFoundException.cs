using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Exceptions
{
    public class OrderNotFoundException : DomainException
    {
        public OrderNotFoundException() : base("Sipariş bulunamadı.") { }

        public OrderNotFoundException(string message) : base(message) { }
    }
}
