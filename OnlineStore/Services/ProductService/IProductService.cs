using OnlineStore.Models;

namespace OnlineStore.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();

        Task<Product?> GetById(int id);

        Task<List<Product>> AddProduct(Product product);

        Task<List<Product>?> Update(int id, Product request);

        Task<List<Product>?> DeleteProduct(int id);

    }
}
