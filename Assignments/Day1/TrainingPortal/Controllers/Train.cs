using Microsoft.AspNetCore.Mvc;

namespace TrainingPortal.Controllers
{
    public class Train : Controller
    {
        public IActionResult Training()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
