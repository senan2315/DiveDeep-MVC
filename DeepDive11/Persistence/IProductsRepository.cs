using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IProductsRepository
    {
        void Add(Products products);
        void Delete(int productId);
        List<Products> GetAll();
        Products? GetById(int productId);
        void Update(Products products);
    }
}
