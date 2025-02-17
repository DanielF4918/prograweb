using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Implementations
{
    public class ShipperDAL : DALGenericoImpl<Shipper>, IShipperDAL
    {
        private readonly NorthwndContext _context;

        public ShipperDAL(NorthwndContext context) : base(context)
        {
            _context = context;
        }

        public List<Shipper> GetAllShippers()
        {
            string query = "sp_GetAllShippers";
            var result = _context.Shippers.FromSqlRaw(query);
            return result.ToList();
        }

        public bool Add(Shipper entity)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddShipper] @CompanyName, @Phone";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@CompanyName",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.CompanyName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Phone",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = (object)entity.Phone ?? DBNull.Value
                    }
                };

                _context.Database.ExecuteSqlRaw(sql, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
