using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DeepDive11.Models;

namespace DeepDive11.Data
{
    public class DeepDiveContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Products> _products { get; set; }
        public DbSet<Booking> _bookings { get; set; }
        public DbSet<BookingProduct> _bookingProducts { get; set; }
        public DbSet<ProductCategory> _productCategories { get; set; }

        public DeepDiveContext(DbContextOptions<DeepDiveContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Identity roller for admin og customer
            var admin = new IdentityRole
            {
                Id = "3bc0bf8b-fa7f-410e-8aa8-6aec18b8da12",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "a68e4ad2-7951-44e7-a0f2-a621fa087641"
            };

            var customer = new IdentityRole
            {
                Id = "c3498dbf-f53a-4c31-ac76-fdb342803cee",
                Name = "customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "96767fe8-e303-4990-92ac-37fd9bbfd78c"
            };

            modelBuilder.Entity<IdentityRole>().HasData(admin, customer);

            modelBuilder.Entity<BookingProduct>()
                .HasKey(bp => new { bp.BookingId, bp.ProductId });

            modelBuilder.Entity<BookingProduct>()
                .HasOne(bp => bp.Booking)
                .WithMany(b => b.BookingProducts)
                .HasForeignKey(bp => bp.BookingId);

            modelBuilder.Entity<BookingProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(p => p.BookingProducts)
                .HasForeignKey(bp => bp.ProductId);

            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => c.ProductCategoryId);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 1, Name = "BCD" },
                new ProductCategory { ProductCategoryId = 2, Name = "Dykkerdragter" },
                new ProductCategory { ProductCategoryId = 3, Name = "Tanke" },
                new ProductCategory { ProductCategoryId = 4, Name = "Maske og Snorkel" },
                new ProductCategory { ProductCategoryId = 5, Name = "Finner" },
                new ProductCategory { ProductCategoryId = 6, Name = "Regulatorsæt" },
                new ProductCategory { ProductCategoryId = 7, Name = "Komplette sæt" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductId = 1,
                    Brand = "Scubapro",
                    Model = "Navigator Lite BCD",
                    PricePerDay = 125,
                    Image = "NavigatorLiteBCD.webp",
                    ProductCategoryId = 1,
                    Sizes = new List<string> { "S", "M", "L" }
                },

                new Products
                {
                    ProductId = 2,
                    Brand = "Scubapro",
                    Model = "BCD Glide",
                    PricePerDay = 140,
                    Image = "BCDGlide.webp",
                    ProductCategoryId = 1,
                    Sizes = new List<string> { "S", "M", "L" }
                },

                new Products
                {
                    ProductId = 3,
                    Brand = "Scubapro",
                    Model = "BCD Hydros Pro",
                    PricePerDay = 200,
                    Image = "HydrosPro.webp",
                    ProductCategoryId = 1,
                    Sizes = new List<string> { "S", "M", "L" }
                },

                new Products
                {
                    ProductId = 4,
                    Brand = "Seac",
                    Model = "BCD Modular",
                    PricePerDay = 145,
                    Image = "BCDModular.webp",
                    ProductCategoryId = 1,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
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
                    ProductCategoryId = 2,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                // Tanke
                new Products
                {
                    ProductId = 13,
                    Brand = "Scubapro",
                    Model = "Tank 5 liter",
                    Volume = 5,
                    PricePerDay = 150,
                    Image = "Tank.jpg",
                    ProductCategoryId = 3
                },

                new Products
                {
                    ProductId = 14,
                    Brand = "Scubapro",
                    Model = "Tank 10 liter",
                    Volume = 10,
                    PricePerDay = 160,
                    Image = "Tank.jpg",
                    ProductCategoryId = 3
                },

                new Products
                {
                    ProductId = 15,
                    Brand = "Scubapro",
                    Model = "Tank 12 liter",
                    Volume = 12,
                    PricePerDay = 170,
                    Image = "Tank.jpg",
                    ProductCategoryId = 3
                },

                new Products
                {
                    ProductId = 16,
                    Brand = "Scubapro",
                    Model = "Tank 15 liter",
                    Volume = 15,
                    PricePerDay = 180,
                    Image = "Tank.jpg",
                    ProductCategoryId = 3
                },

                // Maske og Snorkel
                new Products
                {
                    ProductId = 17,
                    Brand = "Scubapro",
                    Model = "Ghost",
                    PricePerDay = 50,
                    Image = "GhostMaske.jpg",
                    ProductCategoryId = 4
                },

                new Products
                {
                    ProductId = 18,
                    Brand = "Scubapro",
                    Model = "D-Mask",
                    PricePerDay = 60,
                    Image = "DMask.jpg",
                    ProductCategoryId = 4
                },

                new Products
                {
                    ProductId = 19,
                    Brand = "Scubapro",
                    Model = "Spectra Mini",
                    PricePerDay = 50,
                    Image = "SpectraMini.jpg",
                    ProductCategoryId = 4
                },

                new Products
                {
                    ProductId = 20,
                    Brand = "Scubapro",
                    Model = "Crystal VU",
                    PricePerDay = 75,
                    Image = "CrystalVU.jpg",
                    ProductCategoryId = 4
                },

                new Products
                {
                    ProductId = 21,
                    Brand = "Fourth Element",
                    Model = "Scout Kontrast",
                    PricePerDay = 75,
                    Image = "ScoutKontrast.jpg",
                    ProductCategoryId = 4
                },

                new Products
                {
                    ProductId = 22,
                    Brand = "Fourth Element",
                    Model = "Scout Enhance",
                    PricePerDay = 75,
                    Image = "ScoutEnhance.webp",
                    ProductCategoryId = 4
                },

                new Products
                {
                    ProductId = 23,
                    Brand = "Tusa",
                    Model = "Element",
                    PricePerDay = 75,
                    Image = "TUSA.jpg",
                    ProductCategoryId = 4
                },

                // Finner
                new Products
                {
                    ProductId = 24,
                    Brand = "Scubapro",
                    Model = "Jet Fin",
                    PricePerDay = 50,
                    Image = "JetFin.webp",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                new Products
                {
                    ProductId = 25,
                    Brand = "Scubapro",
                    Model = "GO Travel",
                    PricePerDay = 50,
                    Image = "GOTravel.webp",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                new Products
                {
                    ProductId = 26,
                    Brand = "Scubapro",
                    Model = "Seawing Supernova",
                    PricePerDay = 60,
                    Image = "SuperNova.webp",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                new Products
                {
                    ProductId = 27,
                    Brand = "Seac",
                    Model = "Propulsion",
                    PricePerDay = 50,
                    Image = "Propulsion.webp",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                new Products
                {
                    ProductId = 28,
                    Brand = "Seac",
                    Model = "ALA",
                    PricePerDay = 50,
                    Image = "ALA.webp",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                new Products
                {
                    ProductId = 29,
                    Brand = "Fourth Element",
                    Model = "Tech",
                    PricePerDay = 75,
                    Image = "Tech",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                new Products
                {
                    ProductId = 30,
                    Brand = "Fourth Element",
                    Model = "Rec Fin",
                    PricePerDay = 80,
                    Image = "RecFin.jpg",
                    ProductCategoryId = 5,
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" }
                },

                // Regulatorsæt
                new Products
                {
                    ProductId = 31,
                    Brand = "Scubapro",
                    FirstStage = "MK25EVO",
                    SecondStage = "S600",
                    Octopus = "R105",
                    PricePerDay = 125,
                    Image = "RegulatorSæt31.webp",
                    ProductCategoryId = 6
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
                    ProductCategoryId = 6
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
                    ProductCategoryId = 6
                },

                // Komplette sæt
                new Products
                {
                    ProductId = 34,
                    Brand = "Dive Deep",
                    Model = "Komplet dykkersæt",
                    PricePerDay = 760,
                    Image = "DykkerSæt.jpg",
                    ProductCategoryId = 7,
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
                    ProductCategoryId = 7,
                    IncludedItems = new List<string>
                    {
                        "Maske",
                        "Snorkel",
                        "Finner"
                    }
                }
            );
        }
    }
}