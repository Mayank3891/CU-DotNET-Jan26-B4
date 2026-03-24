using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quickloan.Models;

namespace Quickloan.Controllers
{
    public class LoansController : Controller
    {
        private static List<Loan> loans = new List<Loan>()
        {
            new Loan{Id=1,BorrowerName="Rahul",LenderName="ICICI",Amount=50000,Issettled=false},
            new Loan{Id=2,BorrowerName="Aman",LenderName="HDFC",Amount=80000,Issettled=true}
        };
        // GET: LoansController
        public ActionResult Index()
        {
            return View(loans);
        }

        // GET: LoansController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoansController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: LoansController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loanadd)
        {
            loans.Add(loanadd);
            return RedirectToAction(nameof(Index));
           
        }

        // GET: LoansController/Edit/5
        public ActionResult Edit(int id)
        {
            var loanedit = loans.FirstOrDefault(x => x.Id == id);
            return View(loanedit);
        }

        // POST: LoansController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Loan loanedit)
        {

            foreach(var t in loans)
            {
                if (t.Id == loanedit.Id)
                {
                    t.BorrowerName = loanedit.BorrowerName;
                    t.LenderName = loanedit.LenderName;
                    t.Amount = loanedit.Amount;
                    t.Issettled = loanedit.Issettled;
                }
            }
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: LoansController/Delete/5
        public ActionResult Delete(int id)
        {
            var loanDelete = loans.FirstOrDefault(x => x.Id == id);
            return View(loanDelete);
        }

        // POST: LoansController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Loan loanDelete)
        {
            foreach(var loan in loans)
            {
                if(loan.Id == loanDelete.Id)
                {
                    loans.Remove(loan);
                    return RedirectToAction(nameof(Index));

                }
            }
            return NotFound();
        }
    }
}
