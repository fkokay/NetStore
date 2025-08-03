using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.SharedKernel.DTOs
{
    public class ErpProductPriceDto
    {
        public string ProductCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
