using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface ISubUserRepository
    {
        Task<IEnumerable<SubUserEntity>> GetAllAsync();
        Task<SubUserEntity?> GetByIdAsync(int id);
        Task<SubUserEntity?> GetByEmailAsync(string email);
        Task AddAsync(SubUserEntity user);
        Task UpdateAsync(SubUserEntity user);
        Task DeleteAsync(int id);
        Task<bool> BlockUserAsync(int id);
        Task<bool> ActivateUserAsync(int id);
        Task<SubUserEntity?> SignInAsync(string email, string passwordHash);
        Task<IEnumerable<SubUserEntity>> GetUserSubAccountsAsync(int userId);
    }
}
