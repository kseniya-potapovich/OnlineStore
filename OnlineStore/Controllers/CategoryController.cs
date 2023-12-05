using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DTO;
using OnlineStore.Models;
using OnlineStore.Services.CategoryService;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCategoryDto>>> GetAll()
        {
            return await _categoryService.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<GetCategoryDto>> GetById(int id)
        {
          return await _categoryService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCategory([FromBody] CreateCategoryDto category)
        {
            return await _categoryService.AddCategory(category);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update(CreateCategoryDto request)
        {
            return await _categoryService.Update(request);
        }

        [HttpDelete]
        public async Task<ActionResult<GetCategoryDto>> DeleteCategore(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }
    }
}
