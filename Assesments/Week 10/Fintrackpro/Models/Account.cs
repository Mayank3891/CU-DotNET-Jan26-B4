namespace Fintrackpro.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Accountno { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public List<Transaction> transactions = new List<Transaction>();
    }
}
