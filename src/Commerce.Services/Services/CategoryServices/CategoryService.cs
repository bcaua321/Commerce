using AutoMapper;
using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;
using Commerce.Domain.Entities;
using Commerce.Domain.Repositories.CategoryRepository;

namespace Commerce.Services.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository { get; }
        private IMapper mapper { get; }
        public CategoryService(ICategoryRepository categoryRepository, IMapper _mapper)
        {
            _categoryRepository = categoryRepository;
            mapper = _mapper;
        }

        public async Task<CategoryResponse> CreateCategory(CategoryRequest categoryRequest)
        {
            var entity = mapper.Map<Category>(categoryRequest);
            var result = await _categoryRepository.Register(entity);
            var response = mapper.Map<CategoryResponse>(result);

            return response;
        }

        public async Task<CategoryResponse> UpdateCategory(CategoryRequest categoryRequest)
        {
            var entity = mapper.Map<Category>(categoryRequest);
            var result = await _categoryRepository.Update(entity);
            var response = mapper.Map<CategoryResponse>(result);

            return response;
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            var results = await _categoryRepository.GetAll();
            var response = mapper.Map<List<CategoryResponse>>(results);

            return response;
        }

        public async Task<CategoryResponse> GetById(int id)
        {
            var results = await _categoryRepository.GetById(id);
            var response = mapper.Map<CategoryResponse>(results);

            return response;
        }
    }
}
