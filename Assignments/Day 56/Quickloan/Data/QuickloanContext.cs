using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quickloan.Models;

namespace Quickloan.Data
{
    public class QuickloanContext : DbContext
    {
        public QuickloanContext (DbContextOptions<QuickloanContext> options)
            : base(options)
        {
        }

        public DbSet<Quickloan.Models.Loan> Loan { get; set; } = default!;
    }
}
