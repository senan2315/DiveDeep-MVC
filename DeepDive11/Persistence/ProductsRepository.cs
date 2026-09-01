using DeepDive11.Models;
using DeepDive11.Controllers;



namespace DeepDive11.Persistence
{
    public static class ProductsRepository
    {
        private static List<Products> products = new List<Products>
        {

            // BCD
            new Products
            {
                ProductId = 1,
                Brand = "Scubapro",
                Model = "Navigator Lite BCD",
                PricePerDay = 125,
                Image = "NavigatorLiteBCD.webp",
                Category = "BCD",
                Sizes = new List<string> { "S", "M", "L" }
            },
              new Products
            {
                ProductId = 2,
                Brand = "Scubapro",
                Model = "BCD Glide",
                PricePerDay = 140,
                Image = "BCDGlide.webp",
                Category = "BCD",
                Sizes = new List<string> { "S", "M", "L" }
            },

            new Products
            {
                ProductId = 3,
                Brand = "Scubapro",
                Model = "BCD Hydros Pro",
                PricePerDay = 200,
                Image = "HydrosPro.webp",
                Category = "BCD",
                Sizes = new List<string> { "S", "M", "L" }
            },

            new Products
            {
                ProductId = 4,
                Brand = "Seac",
                Model = "BCD Modular",
                PricePerDay = 145,
                Image = "BCDModular.webp",
                Category = "BCD",
                Sizes = new List<string> { "S", "M", "L" }
            },

            // Dykkerdragter
            new Products
            {
                ProductId = 5,
                Brand = "Scubapro",
                Model = "Definition",
                Type = "Våddragt",
                Thickness = 3,
                PricePerDay = 100,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 6,
                Brand = "Scubapro",
                Model = "Definition",
                Type = "Våddragt",
                Thickness = 5,
                PricePerDay = 100,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 7,
                Brand = "Scubapro",
                Model = "Definition",
                Type = "Våddragt",
                Thickness = 7,
                PricePerDay = 100,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {   
                ProductId = 8,
                Brand = "Waterproof",
                Model = "W5",
                Type = "Våddragt",
                Thickness = 3.5,
                PricePerDay = 100,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 9,
                Brand = "Fourth Element",
                Model = "Proteus",
                Type = "Våddragt",
                Thickness = 5,
                PricePerDay = 120,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 10,
                Brand = "Scubapro",
                Model = "Exodry 4.0",
                Type = "Tørdragt",
                PricePerDay = 300,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 11,
                Brand = "Waterproof",
                Model = "D7 Evo",
                Type = "Tørdragt",
                PricePerDay = 320,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 12,
                Brand = "Santi",
                Model = "E.Lite Plus",
                Type = "Tørdragt",
                PricePerDay = 350,
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 13,
                Brand = "Scubapro",
                Volume = 5,
                PricePerDay = 150,
                Category = "Tanke"

            },

            new Products
            {
                ProductId = 14,
                Brand = "Scubapro",
                Volume = 10,
                PricePerDay = 160,
                Category = "Tanke"
            },

            new Products
            {
                ProductId = 15,
                Brand = "Scubapro",
                Volume = 12,
                PricePerDay = 170,
                Category = "Tanke"
            },

            new Products
            {
                ProductId = 16,
                Brand = "Scubapro",
                Volume = 15,
                PricePerDay = 180,
                Category = "Tanke"
            },


            new Products
            {
                ProductId = 17,
                Brand = "Scubapro",
                Model = "Ghost",
                PricePerDay = 50,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 18,
                Brand = "Scubapro",
                Model = "D-Mask",
                PricePerDay = 60,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 19,
                Brand = "Scubapro",
                Model = "Spectra Mini",
                PricePerDay = 50,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 20,
                Brand = "Scubapro",
                Model = "Crystal VU",
                PricePerDay = 75,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 21,
                Brand = "Fourth Element",
                Model = "Scout Kontrast",
                PricePerDay = 75,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 22,
                Brand = "Fourth Element",
                Model = "Scout Enhance",
                PricePerDay = 75,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 23,
                Brand = "Tusa",
                Model = "Element",
                PricePerDay = 75,
                Category = "Maske/Snorkel"
            },

            new Products
            {
                ProductId = 24,
                Brand = "Scubapro",
                Model = "Jet Fin",
                PricePerDay = 50,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 25,
                Brand = "Scubapro",
                Model = "GO Travel",
                PricePerDay = 50,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 26,
                Brand = "Scubapro",
                Model = "Seawing Supernova",
                PricePerDay = 60,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 27,
                Brand = "Seac",
                Model = "Propulsion",
                PricePerDay = 50,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 28,
                Brand = "Seac",
                Model = "ALA",
                PricePerDay = 50,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 29,
                Brand = "Fourth Element",
                Model = "Tech",
                PricePerDay = 75,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 30,
                Brand = "Fourth Element",
                Model = "Rec Fin",
                PricePerDay = 80,
                Category = "Finner",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
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

        public static Products? GetById(int id)
        {
            return products.FirstOrDefault(p => p.ProductId == id);
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
                productToUpdate.Image = product.Image;
                productToUpdate.Category = product.Category;
                productToUpdate.Sizes = product.Sizes;

            }
        }

        
    }

}



