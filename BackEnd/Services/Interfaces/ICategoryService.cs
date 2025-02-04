using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {

        void AddCategory(CategoryDTO category);
        void UpdateCategory(CategoryDTO category);
        void DeleteCategory(int id);
        List<CategoryDTO> GetCategories();
        CategoryDTO GetCategoryById(int id);
    }
}
