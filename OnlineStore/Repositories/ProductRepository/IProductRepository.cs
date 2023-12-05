using OnlineStore.DTO;

namespace OnlineStore.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

        Task<Product> GetById(int id);

        Task<int> AddProduct(Product product);

        Task<int> Update(Product request);

        Task<Product> DeleteProduct(int id);
    }
}
