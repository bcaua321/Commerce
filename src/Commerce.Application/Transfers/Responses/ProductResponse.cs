namespace Commerce.Application.Transfers.Responses;
public class ProductResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPercentage { get; set; }
    public double Rating { get; set; }
    public int Stock { get; set; }
    public string Brand { get; set; }
    public string Thumbnail { get; set; }
    public int CategoryId { get; set; }
    public virtual ICollection<ImageResponse> Images { get; set; }
}

