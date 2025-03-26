using BackEndAM.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAM.Services.Implementations
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperDAL _shipperDAL;

        public ShipperService(IShipperDAL shipperDAL)
        {
            _shipperDAL = shipperDAL;
        }

        public IEnumerable<Shipper> GetAll()
        {
            return _shipperDAL.GetAll();  // Asegúrate de tener un método válido en el DAL
        }

        public Shipper GetById(int id)
        {
            // Si no existe GetById en el DAL, busca en la lista obtenida por GetAll()
            return _shipperDAL.GetAll().FirstOrDefault(s => s.ShipperId == id);
        }

        public void Create(Shipper shipper)
        {
            _shipperDAL.Add(shipper);
        }

        public void Update(Shipper shipper)
        {
            _shipperDAL.Update(shipper);
        }

        public void Delete(int id)
        {
            var shipper = _shipperDAL.Get(id);
            if (shipper != null)
            {
                _shipperDAL.Delete(shipper);
            }
        }
    }
}
