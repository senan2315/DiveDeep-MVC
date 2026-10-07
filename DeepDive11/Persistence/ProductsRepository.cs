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
        public async Task Add(Products products)
        {

            _context._products.Add(products);
            await _context.SaveChangesAsync();
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

        public async Task AddAsync(Products products)
        {
            return await _context._products
                 .ToListAsync();
        }

        public List<Products> Search(string searchTerm) //Laver en liste med proukter der matcher søge ordet
        {
            var normalizedSearchTerm = searchTerm.Trim(); //Fjerner whitespace fra det der er skrevet i søgeboksen

            return _context._products
                .AsNoTracking() //Fjerner tracking af entities da vi læser data.
                .Where(p => //Vælger produkter hvor:
                    (p.Model != null && p.Model.Contains(normalizedSearchTerm)) || //Modelnavnet indeholder søgeordet
                    p.Brand.Contains(normalizedSearchTerm) || //Brand indeholder søgeordet
                    (p.Type != null && p.Type.Contains(normalizedSearchTerm)) || //Type indeholder søgeordet
                    p.Category.Contains(normalizedSearchTerm)) //Kategori indeholder søgeordet
                .ToList(); //Tilføjer de proukter der matcher søgeordet til en liste.
        }

        public async Task<Products?> GetById(int productId)
        {
            return await _context._products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task Update(Products products)
        {
            _context._products.Update(products);
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