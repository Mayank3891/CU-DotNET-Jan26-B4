using GlobalMart.Models;

namespace GlobalMart.Services
{
    public interface IProductServices
    {
        public decimal Returnprice(Products products,string promocode);
    }
}
