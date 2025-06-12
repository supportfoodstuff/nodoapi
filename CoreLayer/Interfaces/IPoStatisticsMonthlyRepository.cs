using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface IPoStatisticsMonthlyRepository
    {
        Task<IEnumerable<PoStatisticsMonthlyEntity>> GetAllAsync();
        Task<PoStatisticsMonthlyEntity?> GetByIdAsync(int id);
        Task<PoStatisticsMonthlyEntity?> GetByMonthAsync(string month);
        Task AddAsync(PoStatisticsMonthlyEntity stats);
        Task UpdateAsync(PoStatisticsMonthlyEntity stats);
        Task DeleteAsync(int id);
    }
}
