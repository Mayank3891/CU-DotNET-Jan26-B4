using Microsoft.AspNetCore.Mvc;
using FrontEnd.Services;

namespace FrontEnd.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _destinationService;

        public TravelController(ITravelService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _destinationService.GetAllAsync();
            return View(destinations);
        }
    }
}