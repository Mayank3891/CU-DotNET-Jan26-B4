using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> _assets = new List<Asset>
        {
            new Asset{Id = 1, Value = 30000 , Description = "Stocks"},
            new Asset{Id = 2, Value = 10000 , Description = "Mutual Funds"},

        };
        public IActionResult Index()
        {
            return View(_assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            return View(_assets.FirstOrDefault(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_assets.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Delete(Asset toDelete)
        {
            foreach (var asset in _assets)
            {
                if (asset.Id == toDelete.Id)
                {
                    _assets.Remove(asset);
                    TempData["Success"] = true;
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}