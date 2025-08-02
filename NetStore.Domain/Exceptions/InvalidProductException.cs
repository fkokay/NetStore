using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Exceptions
{
    public class InvalidProductException : DomainException
    {
        public InvalidProductException() : base("Geçersiz ürün işlemi.") { }

        public InvalidProductException(string message) : base(message) { }
    }
}
