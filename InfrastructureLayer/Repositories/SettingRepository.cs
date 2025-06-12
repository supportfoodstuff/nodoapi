using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly AppDbContext _context;

        public SettingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SettingEntity>> GetAllAsync()
        {
            return await _context.Settings
                .OrderBy(s => s.SettingName)
                .ToListAsync();
        }

        public async Task<IEnumerable<SettingEntity>> GetEditableAsync()
        {
            return await _context.Settings
                .Where(s => s.IsEditable == true)
                .OrderBy(s => s.SettingCategory)
                .ThenBy(s => s.SettingName)
                .ToListAsync();
        }

        public async Task<SettingEntity?> GetByIdAsync(int id)
        {
            return await _context.Settings
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SettingEntity?> GetByKeyAsync(string settingKey)
        {
            return await _context.Settings
                .FirstOrDefaultAsync(s => s.SettingKey == settingKey);
        }

        public async Task AddAsync(SettingEntity setting)
        {
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SettingEntity setting)
        {
            _context.Settings.Update(setting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var setting = await _context.Settings.FindAsync(id);
            if (setting != null)
            {
                _context.Settings.Remove(setting);
                await _context.SaveChangesAsync();
            }
        }
    }
}
