using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class IntegrationSystemParameter
    {
        public int Id { get; set; }
        public int IntegrationSystemId { get; set; }
        public string Key { get; set; } // Örn: api_key, base_url, client_id
        public string Value { get; set; }

        public IntegrationSystem IntegrationSystem { get; set; }
    }
}
