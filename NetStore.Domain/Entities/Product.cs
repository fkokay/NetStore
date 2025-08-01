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
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }

        public Guid BrandId { get; private set; }
        public Brand Brand { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();
        public ICollection<ProductVariation> Variations { get; private set; } = new List<ProductVariation>();

        public Product(string name, decimal price, Guid brandId, Guid categoryId)
        {
            Name = name;
            Price = price;
            BrandId = brandId;
            CategoryId = categoryId;
        }

        public void AddImage(string url)
        {
            Images.Add(new ProductImage(url));
        }
    }
}
