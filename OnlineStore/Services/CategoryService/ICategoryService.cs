using OnlineStore.Models;

namespace OnlineStore.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();

        Task<Category?> GetById(int id);

        Task<List<Category>> AddCategory(Category category);

        Task<List<Category>?> Update(int id, Category request);

        Task<List<Category>?> DeleteCategory(int id);
    }
}
