using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _context.Users
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }

        public async Task<UserEntity?> GetByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserEntity user)
        {
            _context.Users.Update(user);
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
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsActive = true;
                user.UpdatedAt = DateTime.UtcNow;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UserEntity?> SignInAdminAsync(string email, string passwordHash)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash && u.IsActive && u.Role == "admin");

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<UserEntity?> SignInCustomerAsync(string email, string passwordHash)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive && u.Role == "customer");

            if (user != null && user.PasswordHash == passwordHash)
            {
                return user;
            }

            return null;
        }

        public async Task<IEnumerable<UserEntity>> GetCustomersAsync(string search = "", int limit = 100)
        {
            search = search?.ToLower()?.Trim() ?? "";

            return await _context.Users
                .Where(u => u.Role == "customer" &&
                            (u.FullName.ToLower().Contains(search) ||
                             u.Email.ToLower().Contains(search)))
                .OrderBy(u => u.FullName)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalAvailableBalanceAsync()
        {
            return await _context.Users.SumAsync(u => u.AvailableBalance);
        }

        public async Task<decimal> GetTotalCurrentBalanceAsync()
        {
            return await _context.Users.SumAsync(u => u.CurrentBalance);
        }

        public async Task<decimal> GetTotalCreditLimitAsync()
        {
            return await _context.Users.SumAsync(u => u.CreditLimit);
        }

        public async Task<decimal> GetTotalCollateralValueAsync()
        {
            return await _context.Users.SumAsync(u => u.CollateralValue);
        }

    }
}
