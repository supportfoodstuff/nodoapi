using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive == true)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync(int userId, string keyword = "", int limit = 25)
        {
            var query = _context.Products
                .Where(v => v.UserId == userId);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(v =>
                    v.Name.ToLower().Contains(keyword) ||
                    v.Sku.ToLower().Contains(keyword) ||
                    v.UnitPrice.ToString().ToLower().Contains(keyword)
                );
            }

            return await query
                .OrderByDescending(v => v.IsActive)
                .ThenBy(v => v.Name)
                .Take(limit)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<ProductEntity>> GetAllByUserIdAsync(int userId)
        {
            var query = _context.Products
                .Where(v => v.UserId == userId);

            return await query
                .OrderByDescending(v => v.IsActive)
                .ThenBy(v => v.Name)
                .ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductEntity?> GetBySkuAsync(string sku)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Sku == sku);
        }

        public async Task AddAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
