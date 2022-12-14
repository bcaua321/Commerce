using AutoMapper;
using Commerce.Application.ErrorsMessages;
using Commerce.Application.Exceptions;
using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;
using Commerce.Domain.Entities;
using Commerce.Domain.Repositories.ProductRepository;
using FluentValidation;
using FluentValidation.Results;

namespace Commerce.Services.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository { get; }
        private IMapper _mapper { get; }
        private IValidator<ProductRequest> _validator { get; }
        public ProductService(IProductRepository produtoRepository, IMapper mapper, IValidator<ProductRequest> validator)
        {
            _productRepository = produtoRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> DeleteById(int id)
        {
            var exists = await Exists(id);

            if(!exists)
                throw new CommerceException(ProductRequestDbErrorMessages.ProductDontExist);

            await _productRepository.DeleteById(id);

            return true;
        }

        public Task<bool> Exists(int id)
        {
            return _productRepository.Exists(id);
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var productsList = await _productRepository.GetAll();

            var result = _mapper.Map<List<ProductResponse>>(productsList);

            return result;
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            var productEntity = await _productRepository.GetById(id);

            if (productEntity is null)
                throw new CommerceException(ProductRequestDbErrorMessages.ProductDontExist);

            var productResponse = _mapper.Map<ProductResponse>(productEntity);
            return productResponse;
        }

        public async Task<List<ProductResponse>> GetProductsByCategory(string category)
        {
            var productEntityList = await _productRepository.GetByCategory(category);

            var productResponseList = _mapper.Map<List<ProductResponse>>(productEntityList);

            return productResponseList;
        }

        public async Task<ProductResponse> RegisterProduct(ProductRequest product)
        {
            Validate(product);

            var productEntity = _mapper.Map<Product>(product);
            var result =  await _productRepository.Register(productEntity);

            var productResponse = _mapper.Map<ProductResponse>(result);

            return productResponse;
        }

        public async Task<ProductResponse> UpdateProduct(ProductRequest product)
        {
            var exists = await Exists(product.Id);

            if (!exists)
                throw new CommerceException(ProductRequestDbErrorMessages.ProductDontExist);

            var productEntity = _mapper.Map<Product>(product);
            var result = _productRepository.Update(productEntity);

            var productResponse = _mapper.Map<ProductResponse>(result);
            return productResponse;
        }

        private void Validate(ProductRequest product)
        {
            ValidationResult result = _validator.Validate(product);

            if (result.IsValid)
                return;

            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new CommerceValidationException(errors);
        }
    }
}
