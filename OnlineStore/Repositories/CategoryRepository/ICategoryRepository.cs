namespace OnlineStore.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category?> GetById(int id);

        Task<List<Category>> AddCategory(Category category);

        Task<List<Category>?> Update(int id, Category request);

        Task<List<Category>?> DeleteCategory(int id);
    }
}
