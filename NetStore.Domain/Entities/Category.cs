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
        public string Name { get; private set; }
        public Image Image { get; private set; }

        public Guid? ParentCategoryId { get; private set; }
        public Category? ParentCategory { get; private set; }

        public ICollection<Category> SubCategories { get; private set; } = new List<Category>();
        public ICollection<Product> Products { get; private set; } = new List<Product>();

        public Category(string name, Image image)
        {
            Name = name;
            Image = image;
        }
    }
}
