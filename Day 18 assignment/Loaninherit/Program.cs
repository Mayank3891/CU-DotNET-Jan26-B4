namespace Loaninherit
{
    internal class Program
    {
        public class Loan
        {
             public string LoanNumber {  get; set; }
            public string CustomerName {  get; set; }
            public decimal PrincipalAmount {  get; set; }
            public int TenureInYears { get; set; }

             public Loan()
            {
                LoanNumber = "home";
                CustomerName = "Shivam";
                PrincipalAmount = 35000;
                TenureInYears = 5;
                    
            }
            public decimal CalculateEmi()
            {
                return (decimal)((PrincipalAmount + (PrincipalAmount / 10))/TenureInYears);
            }
        }
        class Homeloan : Loan
        {
            public decimal CalculateEmi()
            {
                return (decimal)((PrincipalAmount + (PrincipalAmount / 11)) / TenureInYears);
            }
        }

        class Carloan : Loan
        {
            public decimal CalculateEmi()
            {
                return (decimal)((PrincipalAmount + (PrincipalAmount / 12)) / TenureInYears);
            }
        }
        static void Main(string[] args)
        {
            Loan[] Loans = new Loan[]
            {
                new Carloan(),
                new Homeloan(),
                new Carloan(),
                new Homeloan(),
            };
            for (int i = 0; i < Loans.Length; i++)
            {
                Console.WriteLine(Loans[i].CalculateEmi());
            }


        }
    }
}
