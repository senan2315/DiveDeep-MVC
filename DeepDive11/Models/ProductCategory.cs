namespace DeepDive11.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public List<Products> Products { get; set; } = new();
    }
}