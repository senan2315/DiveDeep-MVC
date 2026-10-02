using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.Models;
using DeepDive11.Persistence;
using DeepDive11API.DTOs;
using Mapster;

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
    }
}
