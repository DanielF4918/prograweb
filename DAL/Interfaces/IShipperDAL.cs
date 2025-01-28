using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IShipperDAL
    {
        Task<List<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Task AddAsync(Shipper shipper);
        Task UpdateAsync(Shipper shipper);
        Task DeleteAsync(int id);
    }
}
