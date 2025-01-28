using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryDAL
    { 
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        List<Category> GetAllCategories();
    }
}
