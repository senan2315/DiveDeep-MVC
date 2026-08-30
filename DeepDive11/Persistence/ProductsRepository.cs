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
              new Products
            {
                Brand = "Scubapro",
                Model = "BCD Glide",
                PricePerDay = 140
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "BCD Hydros Pro",
                PricePerDay = 200
            },

            new Products
            {
                Brand = "Seac",
                Model = "BCD Modular",
                PricePerDay = 145
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "Definition",
                Type = "Våddragt",
                Thickness = 3,
                PricePerDay = 100
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "Definition",
                Type = "Våddragt",
                Thickness = 5,
                PricePerDay = 100
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "Definition",
                Type = "Våddragt",
                Thickness = 7,
                PricePerDay = 100
            },

            new Products
            {
                Brand = "Waterproof",
                Model = "W5",
                Type = "Våddragt",
                PricePerDay = 100
            },

            new Products
            {
                Brand = "Fourth Element",
                Model = "Proteus",
                Type = "Våddragt",
                Thickness = 5,
                PricePerDay = 120
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "Exodry 4.0",
                Type = "Tørdragt",
                PricePerDay = 300
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "Ghost",
                PricePerDay = 50
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "D-Mask",
                PricePerDay = 60
            },

            new Products
            {
                Brand = "Fourth Element",
                Model = "Scout Kontrast",
                PricePerDay = 75
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "Jet Fin",
                PricePerDay = 50
            },

            new Products
            {
                Brand = "Scubapro",
                Model = "GO Travel",
                PricePerDay = 50
            },

            new Products
            {
                Brand = "Fourth Element",
                Model = "Rec Fin",
                PricePerDay = 80
            }
        };

        public static List<Products> GetAll()
        {
            return products;
        }

        public static Products? GetByModel(string model)
        {
            return products.FirstOrDefault(p => p.Model == model);
        }

        public static void Add(Products product)
        {
            if (product == null)
                return;

            products.Add(product);
        }

        public static void Delete(string model)
        {
            products.RemoveAll(p => p.Model == model);
        }

        public static void Update(string model, Products product)
        {
            var productToUpdate = GetByModel(model);

            if (productToUpdate != null)
            {
                productToUpdate.Brand = product.Brand;
                productToUpdate.Model = product.Model;
                productToUpdate.PricePerDay = product.PricePerDay;
                productToUpdate.Type = product.Type;
                productToUpdate.Thickness = product.Thickness;
                productToUpdate.Volume = product.Volume;
            }
        }
    }

}



