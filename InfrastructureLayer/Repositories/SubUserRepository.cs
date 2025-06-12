using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class SubUserRepository : ISubUserRepository
    {
        private readonly AppDbContext _context;

        public SubUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubUserEntity>> GetAllAsync()
        {
            return await _context.SubUsers
                .OrderBy(u => u.Email)
                .ToListAsync();
        }

        public async Task<SubUserEntity?> GetByIdAsync(int id)
        {
            return await _context.SubUsers
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<SubUserEntity?> GetByEmailAsync(string email)
        {
            return await _context.SubUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(SubUserEntity user)
        {
            await _context.SubUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubUserEntity user)
        {
            _context.SubUsers.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> BlockUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                user.UpdatedAt = DateTime.UtcNow;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ActivateUserAsync(int id)
        {
            var user = await _context.SubUsers.FindAsync(id);
            if (user != null)
            {
                user.IsActive = true;
                user.UpdatedAt = DateTime.UtcNow;
                _context.SubUsers.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<SubUserEntity?> SignInAsync(string email, string passwordHash)
        {
            var user = await _context.SubUsers
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);

            if (user != null && user.PasswordHash == passwordHash)
            {
                return user;
            }

            return null;
        }

        public async Task<IEnumerable<SubUserEntity>> GetUserSubAccountsAsync(int userId)
        {
            return await _context.SubUsers
                .Where(u => u.UserId == userId)
                .OrderBy(u => u.Email)
                .ToListAsync();
        }

    }
}
