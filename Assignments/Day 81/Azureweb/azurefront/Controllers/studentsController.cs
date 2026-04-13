using Microsoft.AspNetCore.Mvc;
using azurefront.Models;
using azurefront.Services;

namespace azurefront.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var students = await _service.GetAllAsync();
            return View(students);
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var student = await _service.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(student students)
        {
            if (ModelState.IsValid)
            {
                var success = await _service.CreateAsync(students);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(students);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, student students)
        {
            if (id != students.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var success = await _service.UpdateAsync(id, students);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(students);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}