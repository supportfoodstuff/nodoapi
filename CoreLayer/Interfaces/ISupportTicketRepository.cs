using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface ISupportTicketRepository
    {
        Task<IEnumerable<SupportTicketEntity>> GetAllAsync();
        Task<SupportTicketEntity?> GetByIdAsync(int id);
        Task<IEnumerable<SupportTicketEntity>> GetByUserIdAsync(int userId);
        Task AddAsync(SupportTicketEntity ticket);
        Task UpdateAsync(SupportTicketEntity ticket);
        Task DeleteAsync(int id);
        Task<bool> MarkAsOpenAsync(int id);
        Task<bool> MarkAsClosedAsync(int id);
    }
}
