namespace GlobalMart.Models
{
    public class Finalprice
    {
        public Products Product { get; set; } = new Products();
        public string PromoCode { get; set; }
        public decimal FinalPrice { get; set; }
    }
}