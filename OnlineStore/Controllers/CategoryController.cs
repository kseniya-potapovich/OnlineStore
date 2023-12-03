using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            return await _categoryService.GetAll(); 
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var result = await _categoryService.GetById(id);
            if (result == null)
            {
                return NotFound("No such category exists");
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            var result = await _categoryService.AddCategory(category);
            return result;
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> Update(int id, Category request)
        {
            var result = await _categoryService.Update(id, request);
            if (result == null)
            {
                return NotFound("No such category exists");
            }

            return result;
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategore(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (result == null)
            {
                return NotFound("No such category exists");
            }

            return result;
        }
    }
}
