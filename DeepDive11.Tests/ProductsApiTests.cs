using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DeepDive11.Tests
{
    public class ProductsApiTests : IClassFixture<WebApplicationFactory<DeepDive11API.Program>>
    {
        private readonly HttpClient _client;
        public ProductsApiTests(WebApplicationFactory<DeepDive11API.Program> factory)
        {
            _client = factory.CreateClient();
        }

        // Tester om vores GET-endpoint virker til Products API'et, og om det sender et rigtigt svar tilbage.
        [Fact]
        public async Task GetProductsApiTest() 
        {
            // Act
            var response = await _client.GetAsync("/api/ProductsApi/api/products");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content));
        }
    }
}
