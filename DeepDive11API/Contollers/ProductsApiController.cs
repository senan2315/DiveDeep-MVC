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
        public async Task<ActionResult<Products>> Create(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //Hvis validering fejler send 400
            }

            products.ProductId = 0;
            await _productsRepository.Add(products);
            return CreatedAtAction(nameof(GetById), new { id = products.ProductId }, products); //Returnerer 201 når bogen er lavet.

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
    }
}
