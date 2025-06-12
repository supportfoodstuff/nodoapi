using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class PoActivityLogRepository : IPoActivityLogRepository
    {
        private readonly AppDbContext _context;

        public PoActivityLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PoActivityLogEntity>> GetAllAsync()
        {
            return await _context.PoActivityLogs
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<PoActivityLogEntity?> GetByIdAsync(int id)
        {
            return await _context.PoActivityLogs
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PoActivityLogEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.PoActivityLogs
                .Where(x => x.PurchaseOrderId == purchaseOrderId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(PoActivityLogEntity log)
        {
            await _context.PoActivityLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var log = await _context.PoActivityLogs.FindAsync(id);
            if (log != null)
            {
                _context.PoActivityLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }
    }
}
