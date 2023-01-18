using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;
using Commerce.Services.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        private ICategoryService _categoryService { get; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("List")]
        public Task<List<CategoryResponse>> GetAllCategories()
        {
            var results = _categoryService.GetAllCategories();

            return results;
        }

        [HttpPost("Create")]
        public Task<List<CategoryResponse>> CreateProduct([FromBody]CategoryRequest categoryRequest)
        {
            var results = _categoryService.GetAllCategories();

            return results;
        }

        [HttpPut("Update")]
        public Task<List<CategoryResponse>> UpdateProduct([FromBody] CategoryRequest categoryRequest)
        {
            var results = _categoryService.GetAllCategories();

            return results;
        }
    }
}
