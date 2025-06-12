using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class SupportTicketLogRepository : ISupportTicketLogRepository
    {
        private readonly AppDbContext _context;

        public SupportTicketLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupportTicketLogEntity>> GetAllAsync()
        {
            return await _context.SupportTicketLogs
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();
        }

        public async Task<SupportTicketLogEntity?> GetByIdAsync(int id)
        {
            return await _context.SupportTicketLogs
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<SupportTicketLogEntity>> GetByTicketIdAsync(int supportTicketId)
        {
            return await _context.SupportTicketLogs
                .Where(l => l.SupportTicketId == supportTicketId)
                .OrderBy(l => l.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(SupportTicketLogEntity log)
        {
            await _context.SupportTicketLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var log = await _context.SupportTicketLogs.FindAsync(id);
            if (log != null)
            {
                _context.SupportTicketLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }
    }
}
