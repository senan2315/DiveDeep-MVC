using Microsoft.AspNetCore.Mvc;

namespace DeepDive11.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
