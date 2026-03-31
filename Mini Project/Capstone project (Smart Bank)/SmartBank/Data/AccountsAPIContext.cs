using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountsAPI.Models;

namespace AccountsAPI.Data
{
    public class AccountsAPIContext : DbContext
    {
        public AccountsAPIContext (DbContextOptions<AccountsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AccountsAPI.Models.Account> Account { get; set; } = default!;
    }
}
