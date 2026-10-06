using DeepDive11.Data;
using DeepDive11.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive11.Persistence
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DeepDiveContext _context;

        public ProductsRepository(DeepDiveContext deepDiveContext)
        {
            _context = deepDiveContext;
        }

        public async Task AddAsync(Products products)
        {
            await _context._products.AddAsync(products);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await _context._products
                .Include(p => p.BookingProducts)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
                return;

            if (product.BookingProducts.Any())
                return;

            _context._products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Products>> GetAllAsync()
        {
            return await _context._products
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }

        public async Task<List<Products>> SearchAsync(string searchTerm)
        {
            var normalizedSearchTerm = searchTerm.Trim(); //normalizedSearchTerm gør søgningen mere præcis ved at fjerne unødvendige mellemrum i starten og slutningen af søgetermen. 

            return await _context._products
                .AsNoTracking()
                .Include(p => p.ProductCategory)
                .Where(p =>
                    (p.Model != null && p.Model.Contains(normalizedSearchTerm)) ||
                    p.Brand.Contains(normalizedSearchTerm) ||
                    (p.Type != null && p.Type.Contains(normalizedSearchTerm)) ||
                    (p.ProductCategory != null && p.ProductCategory.Name.Contains(normalizedSearchTerm)))
                .ToListAsync();
        }

        public async Task<Products?> GetByIdAsync(int productId)
        {
            return await _context._products
                .Include(p => p.ProductCategory)
                .Include(p => p.BookingProducts)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task UpdateAsync(Products products)
        {
            _context._products.Update(products);
            await _context.SaveChangesAsync();
        }
    }
}