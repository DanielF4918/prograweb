using FrontEnd.Models;
namespace FrontEnd.Helpers.Interfaces
{
    public interface IShipperHelper
    {
        List<ShipperViewModel> GetShippers();
        ShipperViewModel GetShipper(int? id);
        ShipperViewModel Add(ShipperViewModel shipper);
        ShipperViewModel Update(ShipperViewModel shipper);
        void Delete(int id);
    }
}