using DeepDive11.Data;
using DeepDive11.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive11.Persistence
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DeepDiveContext _context;

        public ProductCategoryRepository(DeepDiveContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await _context._productCategories
                .Include(c => c.Products)
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context._productCategories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.ProductCategoryId == id);
        }

        public async Task AddAsync(ProductCategory category)
        {
            await _context._productCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context._productCategories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.ProductCategoryId == id);

            if (category == null)
                return false;

            if (category.Products.Any())
                return false;

            _context._productCategories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}