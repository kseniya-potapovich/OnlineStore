using OnlineStore.DTO;
using OnlineStore.Models;

namespace OnlineStore.Services.ProductService
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetAll();

        Task<GetProductDto> GetById(int id);

        Task<int> AddProduct(CreateProductDto product);

        Task<int> Update(CreateProductDto request);

        Task<GetProductDto> DeleteProduct(int id);

    }
}
