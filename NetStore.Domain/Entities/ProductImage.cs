namespace NetStore.Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Url { get; private set; }

        public ProductImage(string url)
        {
            Url = url;
        }

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
    }
}