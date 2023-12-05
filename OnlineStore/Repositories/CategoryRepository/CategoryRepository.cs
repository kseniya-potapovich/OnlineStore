
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

namespace OnlineStore.Repositories.CategoryRepository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>?> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<List<Category>?> Update(int id, Category request)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            category.Name = request.Name;
            category.Description = request.Description;

            await _context.SaveChangesAsync();
            return await _context.Categories.ToListAsync();
        }
    }
}
