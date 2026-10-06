using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(int id);
        Task AddAsync(ProductCategory category);
        Task<bool> DeleteAsync(int id);
    }
}