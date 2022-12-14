using Commerce.Application.ErrorsMessages;
using Commerce.Application.Transfers.Requests;
using FluentValidation;

namespace Commerce.Services.Services.ProductServices
{
    public class ProductValidator : AbstractValidator<ProductRequest>
    {
       public ProductValidator() 
       {
            RuleFor(p => p.Price).GreaterThan(0).WithMessage(ProductRequestModelErrorMessages.PriceIsZero);
            RuleFor(p => p.Description).NotEmpty().WithMessage(ProductRequestModelErrorMessages.DescriptionIsEmpty);
            RuleFor(p => p.Thumbnail).NotEmpty().WithMessage(ProductRequestModelErrorMessages.ThumbnailIsEmpty);
            RuleFor(p => p.Images).Must(x => x.Count > 0).WithMessage(ProductRequestModelErrorMessages.ImagesIsEmpty);
            RuleFor(p => p.Brand).NotEmpty().WithMessage(ProductRequestModelErrorMessages.BrandIsEmpty);
            RuleFor(p => p.Title).NotEmpty().WithMessage(ProductRequestModelErrorMessages.TitleIsEmpty);
            RuleFor(p => p.Rating).LessThanOrEqualTo(5).WithMessage(ProductRequestModelErrorMessages.RatingIsMoreThanFive);
            RuleFor(p => p.CategoryId).GreaterThan(0).WithMessage(ProductRequestModelErrorMessages.CategoryIsInvalid);
        }
    }
}
