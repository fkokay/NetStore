using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class IntegrationSystem
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: Trendyol, Logo, PTT Kargo
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<IntegrationSystemParameter> Parameters { get; set; }
    }
}
