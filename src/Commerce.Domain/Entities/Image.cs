namespace Commerce.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Url { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
