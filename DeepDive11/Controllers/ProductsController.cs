using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;
using DeepDive11.Models;

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
        public async Task<IActionResult> Search(string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(Array.Empty<object>());
            }

            // Use the existing synchronous Search method
            var productList = _productsRepository.Search(query);

            var products = productList.Select(product => new
            {
                product.ProductId,
                product.Brand,      
                product.Model,
                product.Type,
                Category = product.ProductCategory?.Name,
                product.Image
            });

            return Json(products);
        }

        public async Task<IActionResult> Category(string id)
        {
            var products = await _productsRepository.GetAll();

            products = products
                .Where(p => p.ProductCategory != null && p.ProductCategory.Name == id)
                .ToList();

            ViewBag.Category = id;

            return View(products);
        }

        public async Task<IActionResult> Rent(int id)
        {
            var product = await _productsRepository.GetById(id);

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
    }
}
