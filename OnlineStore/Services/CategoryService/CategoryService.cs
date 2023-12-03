using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

namespace OnlineStore.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly OnlineStoreDbContext _dbContext;

        public CategoryService(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<List<Category>?> DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<List<Category>?> Update(int id, Category request)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            category.Name = request.Name;
            category.Description = request.Description;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Categories.ToListAsync();
        }
    }
}
