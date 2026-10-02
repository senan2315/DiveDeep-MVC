using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IProductsRepository
    {
        Task Add(Products products);
        void Delete(int productId);
        Task <List<Products>> GetAll();
        List<Products> Search(string searchTerm);
        Task<Products?> GetById(int productId);
        void Update(Products products);
    }
}
