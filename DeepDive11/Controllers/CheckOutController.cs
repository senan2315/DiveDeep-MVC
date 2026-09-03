using DeepDive11.Models;
using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;

namespace DeepDive11.Controllers
{
    public class CheckOutController : Controller
    {
        private static List<RentViewModel> cart = new List<RentViewModel>();

        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(RentViewModel rentViewModel)
        {            
                var product = ProductsRepository
                    .GetById(rentViewModel.Product!.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                if (rentViewModel.EndDate < rentViewModel.StartDate)
                {
                    ModelState.AddModelError(
                        "EndDate",
                        "Slutdato skal være samme dag eller senere end startdato."
                    );
                }

                if (!ModelState.IsValid)
                {
                    rentViewModel.Product = product;

                    return View(
                        "~/Views/Products/Rent.cshtml",
                        rentViewModel
                    );
                }

                rentViewModel.Product = product;

                cart.Add(rentViewModel);

                return RedirectToAction("Index");
            }
        
    }
}
