using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDAL : DALGenericoImpl<Category>, ICategoryDAL
    {
        private NorthwndContext _context;



        public CategoryDAL(NorthwndContext context) : base(context)
        {
            _context = context;

        }



        public List<Category> GetAllCategories()
        {
            string query = "sp_GetAllCategories";

            var resul = _context.Categories
                .FromSqlRaw(query);


            return resul.ToList();
        }

        public bool Add(Category entity)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddCategory] @CategoryName";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@CategoryName",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.CategoryName
                    }
                 };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}