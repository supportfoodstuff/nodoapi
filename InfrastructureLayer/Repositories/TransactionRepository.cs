using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionEntity>> GetAllAsync(int limit = 100, string search = "")
        {
            search = search?.ToLower()?.Trim() ?? "";

            return await _context.Transactions
                .Where(t =>
                    string.IsNullOrEmpty(search) ||
                    t.TransactionType.ToLower().Contains(search) ||
                    t.ReferenceCode.ToLower().Contains(search) ||
                    t.CreatedAt.ToString().ToLower().Contains(search) ||
                    t.Amount.ToString().ToLower().Contains(search))
                .OrderByDescending(t => t.CreatedAt)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<TransactionEntity?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TransactionEntity?> GetByReferenceCodeAsync(string referenceCode)
        {
            return await _context.Transactions
                .FirstOrDefaultAsync(t => t.ReferenceCode == referenceCode);
        }

        public async Task<IEnumerable<TransactionEntity>> GetByUserIdAsync(int userId)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<TransactionEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.Transactions
                .Where(t => t.PurchaseOrderId == purchaseOrderId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(TransactionEntity transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransactionEntity transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
