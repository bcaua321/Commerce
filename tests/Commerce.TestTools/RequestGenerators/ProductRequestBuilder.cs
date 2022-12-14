using Bogus;
using Commerce.Application.Transfers.Requests;

namespace Commerce.TestTools.RequestGenerators
{
    public class ProductRequestBuilder
    {
        public static ProductRequest Builder()
        {

            var imgs = new List<ImageRequest>
            {
                new ImageRequest("https://i.dummyjson.com/data/products/1/1.jpg") ,
                new ImageRequest("https://i.dummyjson.com/data/products/1/2.jpg") ,
                new ImageRequest("https://i.dummyjson.com/data/products/1/3.jpg") ,
                new ImageRequest("https://i.dummyjson.com/data/products/1/4.jpg") ,
                new ImageRequest("https://i.dummyjson.com/data/products/1/thumbnail.jpg")
            };

            var product = new Faker<ProductRequest>()
                .RuleFor(x => x.Description, x => x.Lorem.Word())
                .RuleFor(x => x.Title, x => x.Random.Word())
                .RuleFor(x => x.Brand, x => x.Random.Word())
                .RuleFor(x => x.CategoryId, 1)
                .RuleFor(x => x.Thumbnail, x => x.Internet.Url())
                .RuleFor(x => x.Price, x => x.Finance.Amount() * 2)
                .RuleFor(x => x.DiscountPercentage, x => x.Finance.Amount(min: 1, max: 50))
                .RuleFor(x => x.Stock, x => x.Random.Int(min: 0, max: 1000))
                .RuleFor(x => x.Images, imgs);

            return product;
        }
    }
}
