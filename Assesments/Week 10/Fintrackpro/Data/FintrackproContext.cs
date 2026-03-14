using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fintrackpro.Models;

namespace Fintrackpro.Data
{
    public class FintrackproContext : DbContext
    {
        public FintrackproContext (DbContextOptions<FintrackproContext> options)
            : base(options)
        {
        }

        public DbSet<Fintrackpro.Models.Transaction> Transaction { get; set; } = default!;
        public DbSet<Fintrackpro.Models.Account> Account { get; set; } = default!;
    }
}
