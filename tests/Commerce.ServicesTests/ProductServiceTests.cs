using AutoMapper;
using Commerce.Application.Exceptions;
using Commerce.Application.Mappings;
using Commerce.Application.Transfers.Requests;
using Commerce.Domain.Entities;
using Commerce.Domain.Repositories.ProductRepository;
using Commerce.Services.Services.ProductServices;
using Commerce.TestTools.RequestGenerators;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Commerce.ServicesTests
{
    public class ProductServiceTests
    {
        private IMapper _mapper { get; }
        private IValidator<ProductRequest> _validator { get; }
        private IProductRepository _productRepository { get; }
        private IProductService _productService { get; }

        public ProductServiceTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            }).CreateMapper();
            _validator = new ProductValidator();
            _productRepository = Substitute.For<IProductRepository>(); 
            _productService = new ProductService(_productRepository, _mapper, _validator);
        }

        [Fact]
        public async Task ProductRegisterTest()
        {
            var product = ProductRequestBuilder.Builder();
            var result = _mapper.Map<Product>(product); 

            _productRepository.Register(Arg.Any<Product>()).Returns(result);

            var service = await _productService.RegisterProduct(product);

            Assert.Equal(product.Title, service.Title);
        }

        [Fact]
        public async Task ProductUpdateTest()
        {
            var product = ProductRequestBuilder.Builder();
            var result = _mapper.Map<Product>(product);

            _productRepository.Update(Arg.Any<Product>()).Returns(result);
            _productRepository.Exists(Arg.Any<int>()).Returns(true);

            var service = await _productService.UpdateProduct(product);

            Assert.Equal(product.Title, service.Title);
        }

        [Fact]
        public async Task ProductDontExistsWhenUpdateTest()
        {
            var product = ProductRequestBuilder.Builder();
            var result = _mapper.Map<Product>(product);

            _productRepository.Update(Arg.Any<Product>()).Returns(result);
            _productRepository.Exists(Arg.Any<int>()).Returns(false);

            await Assert.ThrowsAsync<CommerceException>(async () => await _productService.UpdateProduct(product));
        }

        [Fact]
        public async Task ProductGetByIdTest()
        {
            var product = ProductRequestBuilder.Builder();
            var result = _mapper.Map<Product>(product);

            _productRepository.GetById(Arg.Any<int>()).Returns(result);

            var service = await _productService.GetProductById(1);

            Assert.NotNull(service);
        }

        [Fact]
        public async Task ProductDontExistWhenGetByIdTest()
        {
            _productRepository.GetById(Arg.Any<int>()).ReturnsNull();

            await Assert.ThrowsAsync<CommerceException>(async () => await _productService.GetProductById(1));
        }

        [Fact]
        public async Task ProductDeleteTest()
        {
            var product = ProductRequestBuilder.Builder();

            _productRepository.DeleteById(Arg.Any<int>());
            _productRepository.Exists(Arg.Any<int>()).Returns(true);

            var result = await _productService.DeleteById(1);

            Assert.True(result);
        }

    }
}
