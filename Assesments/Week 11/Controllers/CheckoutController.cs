using GlobalMart.Models;
using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace GlobalMart.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IProductServices _productServices;

        // In-memory cart storage (static list)
        private static readonly List<Finalprice> Products = new List<Finalprice>();

        public CheckoutController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Cart action to display cart items
        public IActionResult Cart()
        {
            return View(Products.AsEnumerable());
        }

        
        [HttpGet]
        public IActionResult Discount(int id)
        {
            var product = ProductController.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            var model = new Finalprice
            {
                Product = product,
                FinalPrice = product.price
            };

            return View(model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Discount(Finalprice model)
        {
            if (model?.Product == null)
                return BadRequest();

            var product = ProductController.Products.FirstOrDefault(p => p.Id == model.Product.Id);
            if (product == null)
                return NotFound();

            
            model.FinalPrice = _productServices.Returnprice(product, model.PromoCode);

            model.Product = product;
            return View(model);
        }

        // Add product with promo to cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId, string promoCode)
        {
            var product = ProductController.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return NotFound();

            var finalPrice = _productServices.Returnprice(product, promoCode);

            var cartItem = new Finalprice
            {
                Product = product,
                PromoCode = promoCode,
                FinalPrice = finalPrice
            };

            Products.Add(cartItem);

            return RedirectToAction(nameof(Cart));
        }

        // Remove item from cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int productId)
        {
            var item = Products.FirstOrDefault(c => c.Product.Id == productId);
            if (item != null)
            {
                Products.Remove(item);
            }

            return RedirectToAction(nameof(Cart));
        }
    }
}
