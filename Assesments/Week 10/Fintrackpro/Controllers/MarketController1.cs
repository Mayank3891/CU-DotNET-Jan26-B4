using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Status = "Open";
            ViewData["Top"] = new Tuple<string, long>("Tesla", 40000);
            return View();
        }
    }
}