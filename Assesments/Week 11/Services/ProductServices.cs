using GlobalMart.Models;

namespace GlobalMart.Services
{
    public class ProductServices : IProductServices
    {
        public decimal Returnprice(Products products, string promocode)
        {
            decimal price = products.price;

            if (!string.IsNullOrEmpty(promocode))
            {
                if (promocode.ToUpper() == "WINTER25")
                {
                    decimal discount = price * 0.15m;
                    price -= discount;
                }
                else if (promocode.ToUpper() == "FREESHIP")
                {
                    price -= 5;
                }
            }

            return price;
        }
    }
}