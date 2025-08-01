using NetStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
    }
}
