using DeepDive11.Models;

namespace DeepDive11.ViewModels
{
    public class ManageProductsViewModel
    {
        public List<Products> Products { get; set; } = new();
        public List<ProductCategory> Categories { get; set; } = new();
    }
}