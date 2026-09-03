using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;

namespace DeepDive11.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(string id)
        {
            var products = ProductsRepository
                .GetAll()
                .Where(p => p.Category == id)
                .ToList();

            ViewBag.Category = id;

            return View(products);
            // Finder alle produkter hvor Category matcher den kategori, brugeren klikkede på.
        }

        public IActionResult Rent(int id)
        {
            var product = ProductsRepository.GetById(id);

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
