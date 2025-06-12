using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity?> GetByIdAsync(int id);
        Task<UserEntity?> GetByEmailAsync(string email);
        Task AddAsync(UserEntity user);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(int id);
        Task<UserEntity?> SignInAdminAsync(string email, string passwordHash);
        Task<UserEntity?> SignInCustomerAsync(string email, string passwordHash);
        Task<IEnumerable<UserEntity>> GetCustomersAsync(string search = "", int limit = 100);
        Task<bool> ActivateUserAsync(int id);
        Task<bool> BlockUserAsync(int id);
        Task<decimal> GetTotalAvailableBalanceAsync();
        Task<decimal> GetTotalCurrentBalanceAsync();
        Task<decimal> GetTotalCreditLimitAsync();
        Task<decimal> GetTotalCollateralValueAsync();
    }
}
