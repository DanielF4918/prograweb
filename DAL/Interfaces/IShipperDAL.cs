using Entities.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IShipperDAL : IDALGenerico<Shipper>
    {
        List<Shipper> GetAllShippers();
    }
}
