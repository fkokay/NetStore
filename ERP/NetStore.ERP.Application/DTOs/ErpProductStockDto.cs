using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.Application.DTOs
{
    public class ErpProductStockDto
    {
        public string ProductCode { get; set; }
        public decimal Stock { get; set; }
    }
}
