using Microsoft.AspNetCore.Mvc;

namespace Quickloan.Controllers
{
    public class QuickloanController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
