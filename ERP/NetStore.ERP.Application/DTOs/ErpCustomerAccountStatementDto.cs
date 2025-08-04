using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.ERP.Application.DTOs
{
    public class ErpCustomerAccountStatementDto
    {
        public DateTime Date { get; set; }
        public string DocumentNo { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Debit { get; set; }
        public decimal Credit { get; set; } 
        public decimal Balance { get; set; }
    }
}
