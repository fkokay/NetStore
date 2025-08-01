namespace NetStore.Domain.Entities
{
    public class ProductVariation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Sku { get; set; }
        public required string Name { get; set; }
        public decimal? Price { get; set; }

        public Guid ProductId { get; set; }
        public required Product Product { get; set; }

        public ProductVariation(string sku, string name, decimal? price)
        {
            Sku = sku;
            Name = name;
            Price = price;
        }

        public ProductVariation()
        {

        }
    }
}