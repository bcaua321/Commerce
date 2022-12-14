namespace Commerce.Application.Transfers.Requests
{
    public class ProductRequest
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ImageRequest> Images { get; set; }

    }
}
