using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

namespace OnlineStore.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly OnlineStoreDbContext _dbContext;

        public ProductService(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

             _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<List<Product>?> Update(int id, Product request)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Products.ToListAsync();
        }
    }
}
