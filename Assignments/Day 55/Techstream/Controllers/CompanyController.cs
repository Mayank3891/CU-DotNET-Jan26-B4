using Microsoft.AspNetCore.Mvc;
using Techstream.Models;

namespace Techstream.Controllers
{
    public class CompanyController : Controller
    {
        private readonly List<Employee> employees = new List<Employee>()
        {
            new Employee(1,"Mayank","A1",50000),
            new Employee(1,"Aaroh","A1",50000),
            new Employee(1,"Sahil","A1",50000),
            new Employee(1,"ritik","A1",50000)

        };

        public IActionResult showdata()
        {
            ViewBag.Announcement = "something announced";
            ViewData["status"] = false;

            return View(employees);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
