using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.Models;

namespace NorthwindCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;
        public ProductsController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("api");
        }
        public async Task<IActionResult> ByCategory(int id)
        {
            var response = await _client.GetAsync($"api/products/by-category/{id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("API FAILED: " + response.StatusCode);
                return View(new List<ProductDto>());
            }

            var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

            Console.WriteLine("COUNT: " + (products?.Count ?? 0));

            return View(products ?? new List<ProductDto>());
        }

    }
}
