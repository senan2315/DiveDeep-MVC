using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive11.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetAll();
            return View(products);
        }
    }
}
