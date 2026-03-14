using Microsoft.AspNetCore.Mvc;
using Fintrackpro.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
namespace Fintrackpro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assets = new List<Asset>()
        {
            new Asset{id=1,name="Car",price=8000000,Quantity=4},
             new Asset{id=2,name="Gold",price=300000,Quantity=3},
              new Asset{id=3,name="Silver",price=400000,Quantity=2},
               new Asset{id=4,name="House",price=9000000,Quantity=1},
                new Asset{id=5,name="watch",price=700000,Quantity=4},

        };
        public IActionResult Index()
        {
            var total = assets.Sum(a => a.price * a.Quantity);
            ViewData["total"] = total;
            return View(assets);
        }

        [Route("Asset/Info/{id:int}")]  
    public IActionResult Details(int id)
    {
        var assetss = assets.FirstOrDefault(x => x.id == id);
        return View(assetss);
    }
      public IActionResult  Delete(int id)
        {
            var deleted = assets.FirstOrDefault(x => x.id == id);
            assets.Remove(deleted);
            TempData["success"] = "ITEM DELETED SUCCESSFULLY";
            return View();
        }

    }
}
