using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class RepaymentRepository : IRepaymentRepository
    {
        private readonly AppDbContext _context;

        public RepaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepaymentEntity>> GetAllAsync()
        {
            return await _context.Repayments
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<RepaymentEntity>> GetAllRepayments(string keyword = "", int limit = 25)
        {
            var query = _context.Repayments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(r => r.Status.Contains(keyword));
            }

            return await query
                .OrderByDescending(r => r.CreatedAt)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<RepaymentEntity>> GetRepaymentsAsync(int userId, string keyword = "", int limit = 25)
        {
            var query = _context.Repayments
                .Where(r => r.UserId == userId);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(r =>
                    r.Status.Contains(keyword));
            }

            query = query.Take(limit);

            return await query
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<RepaymentEntity?> GetByIdAsync(int id)
        {
            return await _context.Repayments
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RepaymentEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.Repayments
                .Where(r => r.PurchaseOrderId == purchaseOrderId)
                .OrderBy(r => r.DueDate)
                .ToListAsync();
        }

        public async Task AddAsync(RepaymentEntity repayment)
        {
            await _context.Repayments.AddAsync(repayment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RepaymentEntity repayment)
        {
            _context.Repayments.Update(repayment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repayment = await _context.Repayments.FindAsync(id);
            if (repayment != null)
            {
                _context.Repayments.Remove(repayment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
