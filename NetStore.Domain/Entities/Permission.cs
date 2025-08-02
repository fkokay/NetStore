using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Key { get; set; } // Örn: "orders.view", "orders.ship", "orders.invoice"
        public string Description { get; set; }
    }
}
