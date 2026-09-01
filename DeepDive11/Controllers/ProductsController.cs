using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;

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

            return View(product);
        }
        // Implementer logikken for at leje produktet her, f.eks. opdatering af databasen, betaling osv.
    }
}
