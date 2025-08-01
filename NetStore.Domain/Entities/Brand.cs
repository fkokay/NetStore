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
        public required string Name { get; set; }
        public Image? Logo { get; set; }

        public Brand()
        {

        }
        public Brand(string name, Image? logo)
        {
            Name = name;
            Logo = logo;
        }


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
