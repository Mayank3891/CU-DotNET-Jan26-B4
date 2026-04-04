using Microsoft.AspNetCore.Mvc;
using VoltGear.Models;
using VoltGear.Services;

namespace VoltGear.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopService _service;

        public LaptopController(LaptopService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Laptop laptop)
        {
            if (!ModelState.IsValid)
            {
                return View(laptop);
            }

            await _service.CreateAsync(laptop);

            TempData["msg"] = "Laptop saved successfully!";
            return RedirectToAction("Index");
        }
    }
}