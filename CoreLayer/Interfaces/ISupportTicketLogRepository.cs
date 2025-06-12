using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface ISupportTicketLogRepository
    {
        Task<IEnumerable<SupportTicketLogEntity>> GetAllAsync();
        Task<SupportTicketLogEntity?> GetByIdAsync(int id);
        Task<IEnumerable<SupportTicketLogEntity>> GetByTicketIdAsync(int supportTicketId);
        Task AddAsync(SupportTicketLogEntity log);
        Task DeleteAsync(int id);
    }
}
