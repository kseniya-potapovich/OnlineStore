using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.DTO;
using OnlineStore.Repositories.CategoryRepository;

namespace OnlineStore.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> AddCategory(CreateCategoryDto category)
        {
            var existedCategory = await _categoryRepository.GetById(category.Id);
            if (existedCategory != null)
            {
                throw new Exception("Category exists");
            }
            var categoryToAdd = _mapper.Map<Category>(category);
            return await _categoryRepository.AddCategory(categoryToAdd);
        }

        public async Task<GetCategoryDto> DeleteCategory(int id)
        {
            var categoryToRemove = await _categoryRepository.DeleteCategory(id);
            return _mapper.Map<GetCategoryDto>(categoryToRemove);
        }

        public async Task<List<GetCategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<GetCategoryDto>>(categories);
        }

        public async Task<GetCategoryDto> GetById(int id)
        {
            var categoryToFind = await _categoryRepository.GetById(id);
            return _mapper.Map<GetCategoryDto>(categoryToFind);
        }

        public async Task<int> Update(CreateCategoryDto request)
        {
            var categoryToUpdate = await _categoryRepository.GetById(request.Id);
            if (categoryToUpdate == null)
            {
                throw new Exception("Category is not exist");
            }
            categoryToUpdate = _mapper.Map<Category>(categoryToUpdate);
            return await _categoryRepository.Update(categoryToUpdate);
        }
    }
}
