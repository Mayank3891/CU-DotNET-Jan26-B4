using AccountsAPI.DTO;
using AccountsAPI.Exceptions;
using AccountsAPI.Models;
using AccountsAPI.Helper;

using AccountsAPI.Repositories;

namespace AccountsAPI.Services
{
    public class AccountService:IAccountService
    {
        private IAccountRepository _repository { get; set; }
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<AccountDto> Create(CreateAccountDto createaccountDTO)
        {
            if (createaccountDTO.InitialDeposit < 1000) throw new BadRequestException("Deposit can't be less than 1000");
            Account account = new Account()
            {
                Name = createaccountDTO.Name,
                AccountNumber = "",
                Balance = createaccountDTO.InitialDeposit,
                CreatedAt = DateTime.Now,
            };

            await _repository.create(account);

            account.AccountNumber = AccountNumberGenerator.Generate(account.Id);

            await _repository.Update(account);

            return new AccountDto()
            {
                Id = account.Id,
                Name = account.Name,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
            };

        }
        public async Task<AccountDto?> Read(int id)
        {
            var account = await _repository.Read(id);


            if (account == null)
            {
                throw new NotFoundException($"This account was not found");
            }

            return new AccountDto()
            {
                Id = account.Id,
                Name = account.Name,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
            };
        }

        public async Task<IEnumerable<Account>> ReadAll()
        {
            return await _repository.ReadAll();
        }

        public async Task Update(TransactionDto transactionAccountDTO)
        {
            if (transactionAccountDTO.Amount < 1000) throw new BadRequestException("Balance can't be less than 1000");
            var account = await _repository.Read(transactionAccountDTO.AccountId);

            if (account == null) throw new NotFoundException($"This account was not found");

            account.Balance = transactionAccountDTO.Amount;

            await _repository.Update(account);
        }
    }
}
