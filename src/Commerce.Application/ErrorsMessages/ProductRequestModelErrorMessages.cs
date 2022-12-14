namespace Commerce.Application.ErrorsMessages
{
    public static class ProductRequestModelErrorMessages
    {
        public const string TitleIsEmpty = "Title is required.";
        public const string PriceIsZero = "The price cannot be zero.";
        public const string DescriptionIsEmpty = "Description is required.";
        public const string RatingIsMoreThanFive = "The Rating cannot be more than five.";
        public const string BrandIsEmpty = "Brand is required.";
        public const string CategoryIsInvalid = "Category invalid.";
        public const string ThumbnailIsEmpty = "Thumbnail is required.";
        public const string ImagesIsEmpty = "Images is required.";
    }
}
