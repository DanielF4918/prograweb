using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDAL : IShipperDAL
    {
        private readonly NorthwndContext _context;

        public ShipperDAL(NorthwndContext context)
        {
            _context = context;
        }

        public async Task<List<Shipper>> GetAllAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _context.Shippers.FindAsync(id);
        }

        public async Task AddAsync(Shipper shipper)
        {
            await _context.Shippers.AddAsync(shipper);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipper shipper)
        {
            _context.Shippers.Update(shipper);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                await _context.SaveChangesAsync();
            }
        }
    }
}
