using AccountsAPI.DTO;
using AccountsAPI.Models;

namespace AccountsAPI.Services
{
    public interface IAccountService
    {
        public Task<AccountDto> Create(CreateAccountDto createaccountDTO);
        public Task<AccountDto?> Read(int id);
        public Task<IEnumerable<Account>> ReadAll();
        public  Task Update(TransactionDto transactionAccountDTO)
;

    }
}
