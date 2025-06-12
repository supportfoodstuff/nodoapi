using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _context;

        public VendorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VendorEntity>> GetAllAsync()
        {
            return await _context.Vendors
                .OrderBy(v => v.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<VendorEntity>> GetVendorsAsync(int userId, string? keyword = "", int limit = 25)
        {
            var query = _context.Vendors
                .Where(v => v.UserId == userId);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(v => v.Name.Contains(keyword));
            }

            query = query.Take(limit);

            return await query
                .OrderBy(v => v.Name)
                .ToListAsync();
        }

        public async Task<VendorEntity?> GetByIdAsync(int id)
        {
            return await _context.Vendors
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<VendorEntity?> GetByNameAsync(string name)
        {
            return await _context.Vendors
                .FirstOrDefaultAsync(v => v.Name == name);
        }

        public async Task AddAsync(VendorEntity vendor)
        {
            await _context.Vendors.AddAsync(vendor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VendorEntity vendor)
        {
            _context.Vendors.Update(vendor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
