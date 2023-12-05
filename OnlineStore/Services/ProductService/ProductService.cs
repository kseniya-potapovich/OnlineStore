using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.DTO;
using OnlineStore.Repositories.ProductRepository;

namespace OnlineStore.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> AddProduct(CreateProductDto product)
        {
            var existedProduct = await _productRepository.GetById(product.Id);

            if (existedProduct != null)
            {
                throw new Exception("Product exist");
            }

            var productToAdd = _mapper.Map<Product>(product);
            return await _productRepository.AddProduct(productToAdd);
        }

        public async Task<GetProductDto> DeleteProduct(int id)
        {
            var productToRemove = await _productRepository.DeleteProduct(id);
            return _mapper.Map<GetProductDto>(productToRemove);
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<GetProductDto>>(products);
        }

        public async Task<GetProductDto> GetById(int id)
        {
            var productToFind = await _productRepository.GetById(id);
            return _mapper.Map<GetProductDto>(productToFind);
        }

        public async Task<int> Update(CreateProductDto request)
        {
            var productToUpdate = await _productRepository.GetById(request.Id);
            if (productToUpdate == null)
            {
                throw new Exception("Product is not exist");
            }
            productToUpdate = _mapper.Map<Product>(productToUpdate);
            return await _productRepository.Update(productToUpdate);
        }
    }
}
