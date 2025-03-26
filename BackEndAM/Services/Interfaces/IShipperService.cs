using Entities.Entities;
using System.Collections.Generic;

namespace BackEndAM.Services.Interfaces
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int id);
        void Create(Shipper shipper);
        void Update(Shipper shipper);
        void Delete(int id);
    }
}
