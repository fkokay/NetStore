namespace NetStore.Domain.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }

        public ProductImage(string url)
        {
            Url = url;
        }

        public ProductImage() 
        {
        
        }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}