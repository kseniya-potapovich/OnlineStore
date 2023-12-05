using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DTO;
using OnlineStore.Models;
using OnlineStore.Services.ProductService;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProductDto>>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<GetProductDto>> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddProduct([FromBody] CreateProductDto product)
        {
            return await _productService.AddProduct(product);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update(CreateProductDto request)
        {
            return await _productService.Update(request);
        }

        [HttpDelete]
        public async Task<ActionResult<GetProductDto>> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
