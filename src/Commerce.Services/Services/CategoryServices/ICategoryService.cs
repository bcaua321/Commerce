using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;

namespace Commerce.Services.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<CategoryResponse> CreateCategory(CategoryRequest categoryRequest);
        Task<CategoryResponse> UpdateCategory(CategoryRequest categoryRequest);
        Task<List<CategoryResponse>> GetAllCategories();
    }
}
