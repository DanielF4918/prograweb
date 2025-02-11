using FrontEnd.Models;
using System.Collections.Generic;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IShipperHelper
    {
        List<ShipperViewModel> GetAll();
        ShipperViewModel GetById(int id);
        ShipperViewModel Create(ShipperViewModel model);
        void Update(ShipperViewModel model);
        void Delete(int id);
    }
}
