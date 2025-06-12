using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly AppDbContext _context;

        public PurchaseOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseOrderEntity>> GetAllAsync()
        {
            return await _context.PurchaseOrders
                .OrderByDescending(po => po.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrderEntity>> GetAllPurchaseOrdersAsync(string keyword = "", int limit = 25)
        {
            IQueryable<PurchaseOrderEntity> query = _context.PurchaseOrders;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(po =>
                    po.PoCode.Contains(keyword) ||
                    po.InternalNotes.Contains(keyword) ||
                    po.Amount.ToString().Contains(keyword) ||
                    po.AmountOwedByCustomer.ToString().Contains(keyword)
                );
            }

            return await query
                .OrderByDescending(po => po.CreatedAt)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrderEntity>> GetPurchaseOrdersAsync(int userId, string keyword = "", int limit = 25)
        {
            var query = _context.PurchaseOrders
                .Where(po => po.UserId == userId);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(po =>
                    po.PoCode.Contains(keyword) ||
                    po.InternalNotes.Contains(keyword) ||
                    po.Amount.ToString().Contains(keyword) ||
                    po.AmountOwedByCustomer.ToString().Contains(keyword)
                    );
            }

            query = query
                .OrderByDescending(po => po.CreatedAt)
                .Take(limit);

            return await query.ToListAsync();
        }

        public async Task<PurchaseOrderEntity?> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(po => po.Id == id);
        }

        public async Task<PurchaseOrderEntity?> GetByPoCodeAsync(string poCode)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(po => po.PoCode == poCode);
        }

        public async Task<IEnumerable<PurchaseOrderEntity>> GetByVendorIdAsync(int vendorId)
        {
            return await _context.PurchaseOrders
                .Where(po => po.VendorId == vendorId)
                .OrderByDescending(po => po.CreatedAt)
                .ToListAsync();
        }

        public async Task<PurchaseOrderEntity> AddAsync(PurchaseOrderEntity purchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
            await _context.SaveChangesAsync();

            // Generate PoCode using the newly assigned ID
            purchaseOrder.PoCode = $"PO-{FormatPurchaseId(purchaseOrder.Id)}";

            // Save the updated PoCode
            _context.PurchaseOrders.Update(purchaseOrder);
            await _context.SaveChangesAsync();

            return purchaseOrder;
        }
        private string FormatPurchaseId(int id)
        {
            return id.ToString("D6");
        }

        public async Task UpdateAsync(PurchaseOrderEntity purchaseOrder)
        {
            _context.PurchaseOrders.Update(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var po = await _context.PurchaseOrders.FindAsync(id);
            if (po != null)
            {
                _context.PurchaseOrders.Remove(po);
                await _context.SaveChangesAsync();
            }
        }
    }
}
