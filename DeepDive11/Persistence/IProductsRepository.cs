using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IProductsRepository
    {
        Task Add(Products products);
        Task Delete(int productId);
        Task <List<Products>> GetAll();
        List<Products> Search(string searchTerm);
        Task<Products?> GetById(int productId);
        Task Update(Products products);
        // Check existence of a product category to avoid FK constraint violations
        Task<bool> CategoryExistsAsync(int productCategoryId);

        // Attach existing ProductCategory entity to the provided product; returns true if attached
        Task<bool> AttachCategoryAsync(Products products);
    }
}
