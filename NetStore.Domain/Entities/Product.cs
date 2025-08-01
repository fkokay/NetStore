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
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public Guid? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductVariation> Variations { get; set; } = new List<ProductVariation>();

        public Product(string name, decimal price, Guid? brandId, Guid? categoryId)
        {
            Name = name;
            Price = price;
            BrandId = brandId;
            CategoryId = categoryId;
        }

        public Product()
        {

        }

        public void AddImage(string url)
        {
            Images.Add(new ProductImage(url));
        }
    }
}
