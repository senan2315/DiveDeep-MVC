using Microsoft.AspNetCore.Mvc;

namespace DeepDive11.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Book()
        {
            return View();
        }
    }
}
