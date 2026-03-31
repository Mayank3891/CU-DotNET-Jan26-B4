using AccountsAPI.DTO;
using AccountsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        private IAccountService _service { get; set; }
        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAll()
        {
            return Ok(await _service.ReadAll());
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<AccountDto>> GetById(int id)
        {
            return Ok(await _service.Read(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAccountDto createAccountDTO)
        {
            var createdAccount = await _service.Create(createAccountDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(int id, TransactionDto transactionAccountDTO)
        {
            await _service.Update(transactionAccountDTO);
            return NoContent();
        }
    }
}

