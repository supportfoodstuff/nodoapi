using CoreLayer.Entities;

namespace CoreLayer.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<VendorEntity>> GetAllAsync();
        Task<IEnumerable<VendorEntity>> GetVendorsAsync(int userId, string? keyword = "", int limit = 25);
        Task<VendorEntity?> GetByIdAsync(int id);
        Task<VendorEntity?> GetByNameAsync(string name);
        Task AddAsync(VendorEntity vendor);
        Task UpdateAsync(VendorEntity vendor);
        Task DeleteAsync(int id);
    }
}
