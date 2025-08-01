using NetStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; } 
        public required string Sku { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StokQuantity { get; set; }
    }
}
