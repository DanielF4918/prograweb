using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services.Implementations
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperDAL _shipperDAL;

        public ShipperService(IShipperDAL shipperDAL)
        {
            _shipperDAL = shipperDAL;
        }

        public async Task<List<Shipper>> GetAllAsync()
        {
            return await _shipperDAL.GetAllAsync();
        }

        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _shipperDAL.GetByIdAsync(id);
        }

        public async Task AddAsync(Shipper shipper)
        {
            await _shipperDAL.AddAsync(shipper);
        }

        public async Task UpdateAsync(Shipper shipper)
        {
            await _shipperDAL.UpdateAsync(shipper);
        }

        public async Task DeleteAsync(int id)
        {
            await _shipperDAL.DeleteAsync(id);
        }
    }
}
