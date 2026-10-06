using DeepDive11.Models;
using DeepDive11.Persistence;
using DeepDive11.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive11.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public AdminController(
            IBookingRepository bookingRepository,
            UserManager<ApplicationUser> userManager,
            IProductsRepository productsRepository,
            IProductCategoryRepository productCategoryRepository)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
            _productsRepository = productsRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = _bookingRepository.GetAll();

            var viewModels = new List<AdminBookingViewModel>();

            foreach (var booking in bookings)
            {
                var user = await _userManager.FindByIdAsync(booking.UserId);

                viewModels.Add(new AdminBookingViewModel
                {
                    Booking = booking,
                    Email = user?.Email ?? ""
                });
            }

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            var viewModel = new EditBookingViewModel
            {
                BookingId = booking.BookingId,
                Name = booking.Name,
                PhoneNumber = booking.PhoneNumber,

                Products = booking.BookingProducts.Select(bp => new EditBookingProductViewModel
                {
                    ProductId = bp.ProductId,
                    ProductName = $"{bp.Product?.Brand} {bp.Product?.Model}",
                    StartDate = bp.StartDate,
                    EndDate = bp.EndDate,
                    Quantity = bp.Quantity
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditBookingViewModel viewModel)
        {
            var booking = _bookingRepository.GetById(viewModel.BookingId);

            if (booking == null)
            {
                return NotFound();
            }

            for (int i = 0; i < viewModel.Products.Count; i++)
            {
                var product = viewModel.Products[i];

                if (product.EndDate.Date <= product.StartDate.Date)
                {
                    ModelState.AddModelError(
                        $"Products[{i}].EndDate",
                        "Slutdato skal være senere end startdato.");
                }

                var isAvailable = _bookingRepository.IsProductAvailable(
                    product.ProductId,
                    product.StartDate,
                    product.EndDate,
                    product.Quantity,
                    viewModel.BookingId);

                if (!isAvailable)
                {
                    ModelState.AddModelError(
                        $"Products[{i}].Quantity",
                        "Der er ikke nok af dette produkt ledigt i den valgte periode.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            foreach (var editedProduct in viewModel.Products)
            {
                var bookingProduct = booking.BookingProducts
                    .FirstOrDefault(bp => bp.ProductId == editedProduct.ProductId);

                if (bookingProduct == null)
                {
                    continue;
                }

                bookingProduct.StartDate = editedProduct.StartDate.Date;
                bookingProduct.EndDate = editedProduct.EndDate.Date;
                bookingProduct.Quantity = editedProduct.Quantity;

                var days = (bookingProduct.EndDate - bookingProduct.StartDate).Days;

                bookingProduct.TotalPrice =
                    days *
                    bookingProduct.Product.PricePerDay *
                    bookingProduct.Quantity;
            }

            booking.StartDate = booking.BookingProducts.Min(bp => bp.StartDate);
            booking.EndDate = booking.BookingProducts.Max(bp => bp.EndDate);

            _bookingRepository.Update(booking);

            TempData["SuccessMessage"] = "Bookingen er blevet opdateret.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingRepository.Delete(id);

            TempData["SuccessMessage"] = "Bookingen er blevet slettet.";

            return RedirectToAction(nameof(Index));
        }

        // PRODUKTER OG KATEGORIER

        [HttpGet]
        public async Task<IActionResult> ManageProducts()
        {
            var products = await _productsRepository.GetAllAsync();
            var categories = await _productCategoryRepository.GetAllAsync();

            var viewModel = new ManageProductsViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(
    Products product,
    string? Sizes,
    string? IncludedItems)
        {
            var categories = await _productCategoryRepository.GetAllAsync();

            if (string.IsNullOrWhiteSpace(product.Brand))
            {
                ModelState.AddModelError(
                    "Brand",
                    "Brand skal udfyldes.");
            }

            if (product.PricePerDay <= 0)
            {
                ModelState.AddModelError(
                    "PricePerDay",
                    "Pris pr. dag skal være større end 0.");
            }

            var categoryExists = categories
                .Any(c => c.ProductCategoryId == product.ProductCategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError(
                    "ProductCategoryId",
                    "Du skal vælge en gyldig kategori.");
            }

            // Omdanner størrelser fra tekst til en liste
            if (!string.IsNullOrWhiteSpace(Sizes))
            {
                product.Sizes = Sizes
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(size => size.Trim())
                    .ToList();
            }

            // Omdanner inkluderede ting fra tekst til en liste
            if (!string.IsNullOrWhiteSpace(IncludedItems))
            {
                product.IncludedItems = IncludedItems
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(item => item.Trim())
                    .ToList();
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] =
                    "Produktet kunne ikke tilføjes. Tjek felterne.";

                return RedirectToAction(nameof(ManageProducts));
            }

            await _productsRepository.AddAsync(product);

            TempData["SuccessMessage"] =
                "Produktet er blevet tilføjet.";

            return RedirectToAction(nameof(ManageProducts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);

            if (product == null)
            {
                TempData["ErrorMessage"] = "Produktet blev ikke fundet.";

                return RedirectToAction(nameof(ManageProducts));
            }

            if (product.BookingProducts != null && product.BookingProducts.Any())
            {
                TempData["ErrorMessage"] =
                    "Produktet kan ikke slettes, fordi det indgår i en booking.";

                return RedirectToAction(nameof(ManageProducts));
            }

            await _productsRepository.DeleteAsync(id);

            TempData["SuccessMessage"] = "Produktet er blevet slettet.";

            return RedirectToAction(nameof(ManageProducts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["ErrorMessage"] = "Kategorinavn skal udfyldes.";

                return RedirectToAction(nameof(ManageProducts));
            }

            name = name.Trim();

            var categories = await _productCategoryRepository.GetAllAsync();

            var alreadyExists = categories
                .Any(c => c.Name.ToLower() == name.ToLower());

            if (alreadyExists)
            {
                TempData["ErrorMessage"] = "Kategorien findes allerede.";

                return RedirectToAction(nameof(ManageProducts));
            }

            var category = new ProductCategory
            {
                Name = name
            };

            await _productCategoryRepository.AddAsync(category);

            TempData["SuccessMessage"] = "Kategorien er blevet tilføjet.";

            return RedirectToAction(nameof(ManageProducts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _productCategoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                TempData["ErrorMessage"] = "Kategorien blev ikke fundet.";

                return RedirectToAction(nameof(ManageProducts));
            }

            if (category.Products.Any())
            {
                TempData["ErrorMessage"] =
                    "Kategorien kan ikke slettes, fordi der stadig findes produkter i den.";

                return RedirectToAction(nameof(ManageProducts));
            }

            var deleted = await _productCategoryRepository.DeleteAsync(id);

            if (!deleted)
            {
                TempData["ErrorMessage"] = "Kategorien kunne ikke slettes.";

                return RedirectToAction(nameof(ManageProducts));
            }

            TempData["SuccessMessage"] = "Kategorien er blevet slettet.";

            return RedirectToAction(nameof(ManageProducts));
        }
    }
}