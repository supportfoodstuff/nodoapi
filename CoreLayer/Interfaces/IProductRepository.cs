using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync(int userId, string keyword = "", int limit = 25);
        Task<IEnumerable<ProductEntity>> GetAllByUserIdAsync(int userId);
        Task<ProductEntity?> GetByIdAsync(int id);
        Task<ProductEntity?> GetBySkuAsync(string sku);
        Task AddAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        Task DeleteAsync(int id);
    }
}
