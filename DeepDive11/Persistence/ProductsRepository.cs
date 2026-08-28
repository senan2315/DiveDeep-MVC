using DeepDive11.Models;
using DeepDive11.Controllers;



namespace DeepDive11.Persistence
{
    public static class ProductsRepository
    {
        private static List<Products> products = new List<Products>
        {
            new Products
            {
                Brand = "Scubapro",
                Model = "Navigator Lite BCD",
                PricePerDay = 125,
            },


            
        };
    }

}



