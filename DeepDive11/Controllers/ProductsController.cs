using Microsoft.AspNetCore.Mvc;

namespace DeepDive11.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
