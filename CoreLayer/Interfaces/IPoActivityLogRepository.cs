using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface IPoActivityLogRepository
    {
        Task<IEnumerable<PoActivityLogEntity>> GetAllAsync();
        Task<PoActivityLogEntity?> GetByIdAsync(int id);
        Task<IEnumerable<PoActivityLogEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId);
        Task AddAsync(PoActivityLogEntity log);
        Task DeleteAsync(int id);
    }
}
