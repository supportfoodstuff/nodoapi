using CoreLayer.Entities;

namespace CoreLayer.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrderEntity>> GetAllAsync();
        Task<IEnumerable<PurchaseOrderEntity>> GetAllPurchaseOrdersAsync(string keyword = "", int limit = 25);
        Task<IEnumerable<PurchaseOrderEntity>> GetPurchaseOrdersAsync(int userId, string keyword = "", int limit = 25);
        Task<PurchaseOrderEntity?> GetByIdAsync(int id);
        Task<PurchaseOrderEntity?> GetByPoCodeAsync(string poCode);
        Task<IEnumerable<PurchaseOrderEntity>> GetByVendorIdAsync(int vendorId);
        Task<PurchaseOrderEntity> AddAsync(PurchaseOrderEntity purchaseOrder);
        Task UpdateAsync(PurchaseOrderEntity purchaseOrder);
        Task DeleteAsync(int id);
    }
}
