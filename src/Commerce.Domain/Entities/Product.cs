namespace Commerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual Category Category { get; set; }

    }
}
