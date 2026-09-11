using DeepDive11.Models;
using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;

namespace DeepDive11.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public CheckOutController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        private static List<RentViewModel> cart = new List<RentViewModel>();

        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(RentViewModel rentViewModel)
        {
            var product = _productsRepository
                .GetById(rentViewModel.Product!.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            // Størrelse skal vælges, hvis produktet har størrelser
            if (product.Sizes != null &&
                product.Sizes.Any() &&
                string.IsNullOrEmpty(rentViewModel.SelectedSize))
            {
                ModelState.AddModelError(
                    "SelectedSize",
                    "Du skal vælge en størrelse."
                );
            }

            // Startdato må ikke være i fortiden
            if (rentViewModel.StartDate.HasValue &&
                rentViewModel.StartDate.Value.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "StartDate",
                    "Startdato må ikke være i fortiden."
                );
            }

            // Slutdato skal være senere end startdato
            if (rentViewModel.StartDate.HasValue &&
                rentViewModel.EndDate.HasValue &&
                rentViewModel.EndDate.Value.Date <= rentViewModel.StartDate.Value.Date)
            {
                ModelState.AddModelError(
                    "EndDate",
                    "Slutdato skal være senere end startdato."
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

            var days =
                (rentViewModel.EndDate!.Value.Date -
                 rentViewModel.StartDate!.Value.Date).Days;

            rentViewModel.TotalPrice =
                days *
                product.PricePerDay *
                rentViewModel.Quantity;

            cart.Add(rentViewModel);

            return RedirectToAction("Index");
        }
        
    }
}
