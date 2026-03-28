using GlobalMart.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class ProductController : Controller
    {

        public static List<Products> Products = new List<Products>
    {
        new Products { Id = 1, Name = "Laptop", price = 75000m },
        new Products { Id = 2, Name = "Smartphone", price = 35000m },
        new Products { Id = 3, Name = "Headphones", price = 2000m },
        new Products { Id = 4, Name = "Keyboard", price = 1500m },
        new Products { Id = 5, Name = "Monitor", price = 12000m },
        new Products{ Id = 6, Name = "Mouse", price = 800m }
    };

        public IActionResult Index()
        {
            return View(Products);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Products product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Products.Count + 1;
                Products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        
        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

      
        [HttpPost]
        public IActionResult Edit(Products updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.price = updatedProduct.price;
            }

            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}
