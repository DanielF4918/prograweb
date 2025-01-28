using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void AddCategory(CategoryDTO category)
        {

            var categoryEntity = new Category()
            {
                CategoryName = category.CategoryName

            };

            _unidadDeTrabajo.CategoryDAL.Add(categoryEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            _unidadDeTrabajo.CategoryDAL.Update(category);
            _unidadDeTrabajo.Complete();
        }
    }
}