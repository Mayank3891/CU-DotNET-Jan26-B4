using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.Models;

namespace NorthwindCatalog.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly HttpClient _client;

        public SummaryController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/products/summary");

            if (!response.IsSuccessStatusCode)
                return View(new List<CategorySummaryDto>());

            var data = await response.Content.ReadFromJsonAsync<List<CategorySummaryDto>>();

            return View(data ?? new List<CategorySummaryDto>());
        }
    }
}