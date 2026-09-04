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
                Image = "Våddragt.jpeg",
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
                Image = "Våddragt.jpeg",
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
                Image = "Våddragt.jpeg",
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
                Image = "Våddragt.jpeg",
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
                Image = "Våddragt.jpeg",
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
                Image = "Tørdragt.webp",
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
                Image = "Tørdragt.webp",
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
                Image = "Tørdragt.webp",
                Category = "Dykkerdragter",
                Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
            },

            new Products
            {
                ProductId = 13,
                Brand = "Scubapro",
                Model="Tank 5 liter",
                Volume = 5,
                PricePerDay = 150,
                Image = "Tank.jpg",
                Category = "Tanke"

            },

            new Products
            {
                ProductId = 14,
                Brand = "Scubapro",
                Model = "Tank 10 liter",
                Volume = 10,
                PricePerDay = 160,
                Image = "Tank.jpg",
                Category = "Tanke"
            },

            new Products
            {
                ProductId = 15,
                Brand = "Scubapro",
                Model = "Tank 12 liter",
                Volume = 12,
                PricePerDay = 170,
                Image = "Tank.jpg",
                Category = "Tanke"
            },

            new Products
            {
                ProductId = 16,
                Brand = "Scubapro",
                Model = "Tank 15 liter",
                Volume = 15,
                PricePerDay = 180,
                Image = "Tank.jpg",
                Category = "Tanke"
            },


            new Products
            {
                ProductId = 17,
                Brand = "Scubapro",
                Model = "Ghost",
                PricePerDay = 50,
                Image = "GhostMaske.jpg",
                Category = "Maske og Snorkel"
            },

            new Products
            {
                ProductId = 18,
                Brand = "Scubapro",
                Model = "D-Mask",
                PricePerDay = 60,
                Image = "DMask.jpg",
                Category = "Maske og Snorkel"
            },

            new Products
            {
                ProductId = 19,
                Brand = "Scubapro",
                Model = "Spectra Mini",
                PricePerDay = 50,
                Image = "SpectraMini.jpg",
                Category = "Maske ogSnorkel"
            },

            new Products
            {
                ProductId = 20,
                Brand = "Scubapro",
                Model = "Crystal VU",
                PricePerDay = 75,
                Image = "CrystalVU.jpg",
                Category = "Maske og Snorkel"
            },

            new Products
            {
                ProductId = 21,
                Brand = "Fourth Element",
                Model = "Scout Kontrast",
                PricePerDay = 75,
                Image = "ScoutKontrast.jpg",
                Category = "Maske og Snorkel"
            },

            new Products
            {
                ProductId = 22,
                Brand = "Fourth Element",
                Model = "Scout Enhance",
                PricePerDay = 75,
                Image = "ScoutEnhance.webp",
                Category = "Maske og Snorkel"
            },

            new Products
            {
                ProductId = 23,
                Brand = "Tusa",
                Model = "Element",
                PricePerDay = 75,
                Image = "TUSA.jpg",
                Category = "Maske og Snorkel"
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
            },

            new Products
            {
                ProductId = 31,
                Brand = "Scubapro",
                FirstStage = "MK25EVO",
                SecondStage = "S600",
                Octopus = "R105",
                PricePerDay = 125,
                Image = "RegulatorSæt31.webp",
                Category = "Regulatorsæt"
            },

            new Products
            {
                ProductId = 32,
                Brand = "Scubapro",
                FirstStage = "MK17EVO",
                SecondStage = "C370",
                Octopus = "R095",
                PricePerDay = 100,
                Image = "RegulatorSæt32.jpg",
                Category = "Regulatorsæt"
            },

            new Products
            {
                ProductId = 33,
                Brand = "Scubapro",
                FirstStage = "MK25EVO BT",
                SecondStage = "A700 Carbon BT",
                Octopus = "S270",
                PricePerDay = 150,
                Image = "RegulatorSæt33.webp",
                Category = "Regulatorsæt"
            },
           
            new Products
            {
                ProductId = 34,
                Brand = "Dive Deep",
                Model = "Komplet dykkersæt",
                PricePerDay = 760,
                Image = "DykkerSæt.jpg",
                Category = "Komplette sæt",
                IncludedItems = new List<string>
                {
                   "BCD",
                   "Dykkerdragt",
                   "Regulatorsæt",
                   "Tank",
                   "Finner",
                   "Maske",
                   "Snorkel"
                }
            },

            new Products
            {
                ProductId = 35,
                Brand = "Dive Deep",
                Model = "Komplet snorkelsæt",
                PricePerDay = 650,
                Image = "snorkelsæt.webp",
                Category = "Komplette sæt",
                IncludedItems = new List<string>
                {
                   "Maske",
                   "Snorkel",
                   "Finner"
                }
            },

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



