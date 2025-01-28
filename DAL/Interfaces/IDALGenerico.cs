using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IDALGenerico<TEntity> where TEntity : class
    {

        bool Add(TEntity entity);

        bool Update(TEntity entity);
        bool Delete(TEntity entity);

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}
