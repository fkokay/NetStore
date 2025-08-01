namespace NetStore.Domain.Entities
{
    public class ProductVariation
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Sku { get; private set; }
        public string Name { get; private set; }
        public decimal? Price { get; private set; }

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        public ProductVariation(string sku, string name, decimal? price)
        {
            Sku = sku;
            Name = name;
            Price = price;
        }
    }
}