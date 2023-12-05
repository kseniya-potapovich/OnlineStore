namespace OnlineStore.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(int id);

        Task<int> AddCategory(Category category);

        Task<int> Update(Category request);

        Task<Category> DeleteCategory(int id);
    }
}
