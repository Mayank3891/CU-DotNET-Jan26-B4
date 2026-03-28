using FinTrackPro.Data;
using FinTrackPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTrackPro.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FinTrackProContext _context;

        public TransactionsController(FinTrackProContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var finTrackProContext = _context.Transaction.Include(t => t.account);
            return View(await finTrackProContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.account)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }
        public IActionResult MoneySent(int sendeid)
        {
            ViewBag.FromAccountId = sendeid;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> moneysent(int sendeid,int recieveid,double amount)
        {
            var fromAccount = await _context.Account.FindAsync(sendeid);
            var toAccount = await _context.Account.FindAsync(recieveid);

            if (fromAccount == null || toAccount == null)
            {
                return NotFound();
            }

            
            if (sendeid == recieveid)
            {
                ModelState.AddModelError("", "Cannot transfer to same account");
                return View();
            }

            
            if (fromAccount.Balance < amount)
            {
                ModelState.AddModelError("", "Insufficient Balance");
                return View();
            }

            
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
            var debitTxn = new Transaction
            {
                AccountId = sendeid,
                Amount = amount,
                Description = "transfer",
                Category="debit"
                ,
                Date = DateTime.Now
            };

            
            var creditTxn = new Transaction
            {
                AccountId = recieveid,
                Amount = amount,
                Description = "transfer",
                Category = "credit",
                Date = DateTime.Now
            };

            _context.Transaction.Add(debitTxn);
            _context.Transaction.Add(creditTxn);

            await _context.SaveChangesAsync(); 

            return RedirectToAction("Index", "Accounts");

        }
        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AccountId");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                
                var account = await _context.Account
                                .FirstOrDefaultAsync(a => a.AccountId == transaction.AccountId);

                if (account != null)
                {
                    
                    if (transaction.Category.ToLower() == "credit")
                    {
                        account.Balance += transaction.Amount;
                    }
                    
                    else if(transaction.Category.ToLower() == "debit")
                    {
                        account.Balance -= transaction.Amount;
                    }

                }

                
                _context.Transaction.Add(transaction);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Accounts");
            }

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AccountId", transaction.AccountId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AccountId", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.account)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}