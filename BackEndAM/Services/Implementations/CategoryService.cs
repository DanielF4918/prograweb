using BackEndAM.DTO;
using BackEndAM.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEndAM.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Category Convertir(CategoryDTO category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
        CategoryDTO Convertir(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public void AddCategory(CategoryDTO category)
        {

            var categoryEntity = Convertir(category);

            _unidadDeTrabajo.CategoryDAL.Add(categoryEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteCategory(int id)
        {
            var category = _unidadDeTrabajo.CategoryDAL.Get(id);
            if (category != null)
            {
                _unidadDeTrabajo.CategoryDAL.Delete(category);
                _unidadDeTrabajo.Complete();
            }
        }

        public List<CategoryDTO> GetCategories()
        {
            var result = _unidadDeTrabajo.CategoryDAL.GetAllCategories();

            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (var item in result)
            {
                categories
                    .Add(Convertir(item));
            }
            return categories;
        }

        public void UpdateCategory(CategoryDTO category)
        {
            var categoryEntity = Convertir(category);
            _unidadDeTrabajo.CategoryDAL.Update(categoryEntity);
            _unidadDeTrabajo.Complete();
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var result = _unidadDeTrabajo.CategoryDAL.Get(id);
            return Convertir(result);

        }
    }
}