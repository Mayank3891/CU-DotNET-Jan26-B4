using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using carproject.frontend.Models;

namespace carproject.frontend.Controllers
{
    public class CarsController : Controller
    {
        private readonly HttpClient _http;

        public CarsController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

       
        public async Task<IActionResult> Index()
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<List<CarDto>>>("api/cars");
            return View(response?.Data);
        }

     
        public async Task<IActionResult> Details(int id)
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<CarDto>>($"api/cars/{id}");
            return View(response?.Data);
        }

       
        public IActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var res = await _http.PostAsJsonAsync("api/cars", dto);

            if (res.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error creating car");
            return View(dto);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<CarDto>>($"api/cars/{id}");
            return View(response?.Data);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateCarDto dto)
        {
            var res = await _http.PutAsJsonAsync($"api/cars/{id}", dto);

            if (res.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Error updating car");
            return View(dto);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _http.GetFromJsonAsync<ApiResponse<CarDto>>($"api/cars/{id}");
            return View(response?.Data);
        }

        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _http.DeleteAsync($"api/cars/{id}");
            return RedirectToAction("Index");
        }
    }
}