using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class PoStatisticsMonthlyRepository : IPoStatisticsMonthlyRepository
    {
        private readonly AppDbContext _context;

        public PoStatisticsMonthlyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PoStatisticsMonthlyEntity>> GetAllAsync()
        {
            return await _context.PoStatisticsMonthly
                .OrderByDescending(x => x.Month)
                .ToListAsync();
        }

        public async Task<PoStatisticsMonthlyEntity?> GetByIdAsync(int id)
        {
            return await _context.PoStatisticsMonthly
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PoStatisticsMonthlyEntity?> GetByMonthAsync(string month)
        {
            return await _context.PoStatisticsMonthly
                .FirstOrDefaultAsync(x => x.Month == month);
        }

        public async Task AddAsync(PoStatisticsMonthlyEntity stats)
        {
            await _context.PoStatisticsMonthly.AddAsync(stats);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PoStatisticsMonthlyEntity stats)
        {
            _context.PoStatisticsMonthly.Update(stats);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.PoStatisticsMonthly.FindAsync(id);
            if (record != null)
            {
                _context.PoStatisticsMonthly.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
