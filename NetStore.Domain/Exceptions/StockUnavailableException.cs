using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Exceptions
{
    public class StockUnavailableException : DomainException
    {
        public StockUnavailableException() : base("Yeterli stok bulunmamaktadır.") { }

        public StockUnavailableException(string message) : base(message) { }
    }
}
