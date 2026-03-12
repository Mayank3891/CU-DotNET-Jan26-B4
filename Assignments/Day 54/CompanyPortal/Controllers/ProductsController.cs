using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Software()
    {
        return View();
    }

    public IActionResult Tools()
    {
        return View();
    }
}
