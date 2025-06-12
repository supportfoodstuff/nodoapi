using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface IPurchaseOrderItemRepository
    {
        Task<IEnumerable<PurchaseOrderItemEntity>> GetAllAsync();
        Task<IEnumerable<PurchaseOrderItemEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId);
        Task<PurchaseOrderItemEntity?> GetByIdAsync(int id);
        Task AddAsync(PurchaseOrderItemEntity item);
        Task UpdateAsync(PurchaseOrderItemEntity item);
        Task DeleteAsync(int id);
    }
}
