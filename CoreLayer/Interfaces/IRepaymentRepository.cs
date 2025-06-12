using CoreLayer.Entities;
using System.Collections.Generic;

namespace CoreLayer.Interfaces
{
    public interface IRepaymentRepository
    {
        Task<IEnumerable<RepaymentEntity>> GetAllAsync();
        Task<IEnumerable<RepaymentEntity>> GetRepaymentsAsync(int userId, string keyword = "", int limit = 25);
        Task<IEnumerable<RepaymentEntity>> GetAllRepayments(string keyword = "", int limit = 25);
        Task<RepaymentEntity?> GetByIdAsync(int id);
        Task<IEnumerable<RepaymentEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId);
        Task AddAsync(RepaymentEntity repayment);
        Task UpdateAsync(RepaymentEntity repayment);
        Task DeleteAsync(int id);
    }
}
