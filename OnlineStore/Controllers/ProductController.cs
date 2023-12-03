using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var result = await _productService.GetById(id);
            if(result == null)
            {
                return NotFound("No such product exists");
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var result = await _productService.AddProduct(product);
            return result;
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> Update(int id, Product request)
        {
            var result = await _productService.Update(id, request);
            if(result == null)
            {
                return NotFound("No such product exists");
            }

            return result;
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == null)
            {
                return NotFound("No such product exists");
            }
      
            return result;
        }
    }
}
