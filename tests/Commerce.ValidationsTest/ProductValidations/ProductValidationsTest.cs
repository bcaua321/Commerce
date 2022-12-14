using Commerce.Application.ErrorsMessages;
using Commerce.Application.Transfers.Requests;
using Commerce.Services.Services.ProductServices;
using Commerce.TestTools.RequestGenerators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace Commerce.ValidationsTest.ProductValidations
{
    public class ProductValidationsTest
    {
        private IValidator<ProductRequest> _validator { get; }

        public ProductValidationsTest()
        {
            _validator = new ProductValidator();
        }

        [Fact]
        public void ProductTitleIsEmpty()
        {
            var product = ProductRequestBuilder.Builder();
            product.Title = "";

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.TitleIsEmpty));
        }

        [Fact]
        public void ProductDescriptionIsEmpty()
        {
            var product = ProductRequestBuilder.Builder();
            product.Description = "";

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.DescriptionIsEmpty));
        }

        [Fact]
        public void ProductThumbnailIsEmpty()
        {
            var product = ProductRequestBuilder.Builder();
            product.Thumbnail = "";

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.ThumbnailIsEmpty));
        }

        [Fact]
        public void ProductBrandIsEmpty()
        {
            var product = ProductRequestBuilder.Builder();
            product.Brand = "";

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.BrandIsEmpty));
        }

        [Fact]
        public void ProductPriceIsZero()
        {
            var product = ProductRequestBuilder.Builder();
            product.Price = 0;

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.PriceIsZero));
        }

        [Fact]
        public void ProductImagesIsEmpty()
        {
            var product = ProductRequestBuilder.Builder();
            product.Images = new List<ImageRequest>();

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.ImagesIsEmpty));
        }

        [Fact]
        public void CategoryIdIsInvalid()
        {
            var product = ProductRequestBuilder.Builder();
            product.CategoryId = -32;

            var result = _validator.Validate(product);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(err => err.ErrorMessage.Equals(ProductRequestModelErrorMessages.CategoryIsInvalid));
        }
    }
}
