using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IProductsRepository
    {
        void Add(Products products);
        void Delete(int productId);
        List<Products> GetAll();
        List<Products> Search(string searchTerm);
        Products? GetById(int productId);
        void Update(Products products);
    }
}
