using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {

        void AddCategory(CategoryDTO category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        List<Category> GetCategories();
    }
}