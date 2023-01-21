using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;
using Commerce.Services.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService { get; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoryResponse>))]
        public async Task<IActionResult> GetAllCategories()
        {
            var results = await _categoryService.GetAllCategories();

            return Ok(results);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CategoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CategoryRequest categoryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToList());

            var result = await _categoryService.CreateCategory(categoryRequest);

            return Created(nameof(GetAllCategories), result);
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(CategoryRequest categoryRequest)
        {
            var results = await _categoryService.UpdateCategory(categoryRequest);

            return Ok(results);
        }
    }
}
