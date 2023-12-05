using OnlineStore.DTO;
using OnlineStore.Models;

namespace OnlineStore.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAll();

        Task<GetCategoryDto> GetById(int id);

        Task<int> AddCategory(CreateCategoryDto category);

        Task<int> Update(CreateCategoryDto request);

        Task<GetCategoryDto> DeleteCategory(int id);
    }
}
