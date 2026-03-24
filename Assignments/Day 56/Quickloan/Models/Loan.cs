using System.ComponentModel.DataAnnotations;

namespace Quickloan.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Borrower name is required")]
        [Display (Name ="Borrower Name")]
        public string BorrowerName { get; set; }
        [Display(Name = "Borrower Name")]
        public string LenderName { get; set; }
        [Range(1,500000,ErrorMessage ="Loan must between 1 and 500000")]
        public double Amount { get; set; }
        [Display(Name = "Loan Settled ")]
        public bool Issettled { get; set; }
    }
}
