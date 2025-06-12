using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class PurchaseOrderItemRepository : IPurchaseOrderItemRepository
    {
        private readonly AppDbContext _context;

        public PurchaseOrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseOrderItemEntity>> GetAllAsync()
        {
            return await _context.PurchaseOrderItems
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrderItemEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _context.PurchaseOrderItems
                .Where(x => x.PurchaseOrderId == purchaseOrderId)
                .OrderBy(x => x.PurchaseOrderId)
                .ToListAsync();
        }

        public async Task<PurchaseOrderItemEntity?> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrderItems
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(PurchaseOrderItemEntity item)
        {
            await _context.PurchaseOrderItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrderItemEntity item)
        {
            _context.PurchaseOrderItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.PurchaseOrderItems.FindAsync(id);
            if (item != null)
            {
                _context.PurchaseOrderItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
