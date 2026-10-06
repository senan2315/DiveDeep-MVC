using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IProductsRepository
    {
        Task AddAsync(Products products);
        Task DeleteAsync(int productId);
        Task<List<Products>> GetAllAsync();
        Task<List<Products>> SearchAsync(string searchTerm);
        Task<Products?> GetByIdAsync(int productId);
        Task UpdateAsync(Products products);
    }
}
