using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDAL : DALGenericoImpl<Category>,  ICategoryDAL
    {
        private NorthwndContext _context;

        public CategoryDAL(NorthwndContext context): base(context)
        {
            _context = context;
        }
 

    }
}
