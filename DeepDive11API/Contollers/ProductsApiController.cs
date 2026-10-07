using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.Models;
using DeepDive11.Persistence;
using DeepDive11API.DTOs;
using Mapster;
using DeepDive11.Controllers;

namespace DeepDive11API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsApiController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<ActionResult<List<Products>>> GetAll()
        {
            var books = await _productsRepository.GetAll();

            var response = books.Adapt<List<ProductsResponse>>();
            return Ok(response);
        }

        [HttpPost]
        [Route("api/products")]
        public async Task<ActionResult<Products>> Create(CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var products = request.Adapt<Products>();
            products.ProductId = 0;
            await _productsRepository.Add(products);
            return CreatedAtAction(
                nameof(GetById),
                new { productId = products.ProductId },
                products 
            );

        }

        [HttpGet("{productId}")]
        [Route("api/products/{productId}")]
        public async Task<ActionResult<ProductsResponse>> GetById(int productId)
        {
            var product = await _productsRepository.GetById(productId);
            if (product == null) return NotFound();
            var response = product.Adapt<ProductsResponse>();
            return Ok(response);
        }

        [HttpPut]
        [Route("api/products/{productId}")]
        public async Task<IActionResult> Update(int productId, UpdateProductRequest request)
        {
            var existingProduct = await _productsRepository.GetById(productId);
            if (existingProduct == null) 
            {
                return NotFound();
            }
            existingProduct.Brand = request.Brand;
            existingProduct.Model = request.Model;
            existingProduct.PricePerDay = request.PricePerDay;
            existingProduct.Type = request.Type;
            existingProduct.Category = request.Category;
            existingProduct.Image = request.Image;
            existingProduct.Description = request.Description;
            await _productsRepository.Update(existingProduct);
            return NoContent();
        }

        [HttpDelete]
        [Route("api/products/{productId}")]
        public async Task<IActionResult> Delete(int productId) 
        {
            var product = await _productsRepository.GetById(productId);
            if (product == null) 
            {
                return NotFound();
            }
            await _productsRepository.Delete(productId);
            return NoContent();

        }
    }
}
