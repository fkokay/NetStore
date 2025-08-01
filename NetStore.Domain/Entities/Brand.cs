using NetStore.Domain.Common;
using NetStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; private set; }
        public Image Logo { get; private set; }

        public Brand(string name, Image logo)
        {
            Name = name;
            Logo = logo;
        }

        public ICollection<Product> Products { get; private set; } = new List<Product>();
    }
}
