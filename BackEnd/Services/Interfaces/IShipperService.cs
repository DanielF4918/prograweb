using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IShipperService
    {
        Task<List<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Task AddAsync(Shipper shipper);
        Task UpdateAsync(Shipper shipper);
        Task DeleteAsync(int id);
    }
}
