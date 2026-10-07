using DeepDive11.Data;
using DeepDive11.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeepDive11.Persistence
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DeepDiveContext _context;

        public ProductsRepository(DeepDiveContext deepDiveContext)
        {
            _context = deepDiveContext;
        }
        public async Task Add(Products products)
        {

            await _context._products.AddAsync(products);
            await _context.SaveChangesAsync();
        }

        // Helper used by controller to validate FK existence before attempting insert
        public async Task<bool> CategoryExistsAsync(int productCategoryId)
        {
            return await _context._productCategories.AnyAsync(c => c.ProductCategoryId == productCategoryId);
        }

        public async Task<bool> AttachCategoryAsync(Products products)
        {
            if (products == null || products.ProductCategoryId <= 0)
                return false;

            var category = await _context._productCategories.FindAsync(products.ProductCategoryId);
            if (category == null)
                return false;

            // Ensure the category is attached to the context so EF won't try to insert it
            var entry = _context.Entry(category);
            if (entry.State == EntityState.Detached)
            {
                _context._productCategories.Attach(category);
            }

            products.ProductCategory = category;
            return true;
        }

        public async Task Delete(int productId)
        {
            var products = await _context._products.FindAsync(productId);
            if (products != null) 
            {
            _context._products.Remove(products);
            await _context.SaveChangesAsync();
            }
        }


        public async Task<Products?> GetById(int productId)
        {
            return await _context._products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task Update(Products products)
        {
            _context._products.Update(products);
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

        public async Task<List<Products>> GetAll()
        {
            return await _context._products
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }

        public List<Products> Search(string searchTerm)
        {
            var normalizedSearchTerm = searchTerm.Trim(); //normalizedSearchTerm gør søgningen mere præcis ved at fjerne unødvendige mellemrum i starten og slutningen af søgetermen. 

            return _context._products
                .AsNoTracking()
                .Include(p => p.ProductCategory)
                .Where(p =>
                    (p.Model != null && p.Model.Contains(normalizedSearchTerm)) ||
                    p.Brand.Contains(normalizedSearchTerm) ||
                    (p.Type != null && p.Type.Contains(normalizedSearchTerm)) ||
                    (p.ProductCategory != null && p.ProductCategory.Name.Contains(normalizedSearchTerm)))
                .ToList();
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