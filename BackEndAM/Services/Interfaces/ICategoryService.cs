using BackEndAM.DTO;
using Entities.Entities;

namespace BackEndAM.Services.Interfaces
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