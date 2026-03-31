using AccountsAPI.Data;
using AccountsAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace AccountsAPI.Repositories
  
{
    public class AccountRepository:IAccountRepository
    {
         public AccountsAPIContext _context { get; set; }
        public AccountRepository(AccountsAPIContext context)
        {
            _context = context;
        }
        public async Task create(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account?> Read(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> ReadAll()
        {
            return await _context.Account.ToListAsync();
        }
    }
}
