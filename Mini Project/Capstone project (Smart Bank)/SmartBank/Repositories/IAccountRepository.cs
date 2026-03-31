using AccountsAPI.Models;

namespace AccountsAPI.Repositories
{
    public interface IAccountRepository
    {
        public  Task create(Account account);
        public  Task Update(Account account);
        public  Task<Account?> Read(int id);
        public  Task<IEnumerable<Account>> ReadAll();
    }
}
