using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface ISettingRepository
    {
        Task<IEnumerable<SettingEntity>> GetAllAsync();
        Task<IEnumerable<SettingEntity>> GetEditableAsync();
        Task<SettingEntity?> GetByIdAsync(int id);
        Task<SettingEntity?> GetByKeyAsync(string settingKey);
        Task AddAsync(SettingEntity setting);
        Task UpdateAsync(SettingEntity setting);
        Task DeleteAsync(int id);
    }
}
