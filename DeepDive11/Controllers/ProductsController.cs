using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;

namespace DeepDive11.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string? query)
        {
            if (string.IsNullOrWhiteSpace(query)) //hvis query er null, tom eller kun whitespace, returnes en tom liste
            {
                return Json(Array.Empty<object>());
            }

            var products = _productsRepository.Search(query) // Søger efter produkter som matchet det der er skrevet i søge-feltet og returnerer en liste med de produkter der matcher søgningen.
                .Select(product => new 
                {
                    product.ProductId,
                    product.Brand,
                    product.Model,
                    product.Type,
                    product.Category,
                    product.Image
                });

            return Json(products); //Sender listen med produkter til JSON så Javascript Kan bruge dette.
        }

        public IActionResult Category(string id)
        {
            var products = _productsRepository
                .GetAll()
                .Where(p => p.Category == id)
                .ToList();

            ViewBag.Category = id;

            return View(products);
            // Finder alle produkter hvor Category matcher den kategori, brugeren klikkede på.
        }

        public IActionResult Rent(int id)
        {
            var product = _productsRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            
            var rentViewModel = new RentViewModel
            {
                Product = product,
                Quantity = 1,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            return View(rentViewModel);
        }
        // Implementer logikken for at leje produktet her, f.eks. opdatering af databasen, betaling osv.
    }
}
