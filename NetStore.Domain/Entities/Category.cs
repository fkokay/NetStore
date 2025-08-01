using NetStore.Domain.Common;
using NetStore.Domain.ValueObjects;
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
        public Image? Image { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Category(string name, Image? image)
        {
            Name = name;
            Image = image;
        }

        public Category()
        {

        }
    }
}
