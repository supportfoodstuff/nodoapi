using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionEntity>> GetAllAsync(int limit = 100, string search = "");
        Task<TransactionEntity?> GetByIdAsync(int id);
        Task<TransactionEntity?> GetByReferenceCodeAsync(string referenceCode);
        Task<IEnumerable<TransactionEntity>> GetByUserIdAsync(int userId);
        Task<IEnumerable<TransactionEntity>> GetByPurchaseOrderIdAsync(int purchaseOrderId);
        Task AddAsync(TransactionEntity transaction);
        Task UpdateAsync(TransactionEntity transaction);
        Task DeleteAsync(int id);
    }
}
