using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Techstream.Models;

namespace Techstream.Data
{
    public class TechstreamContext : DbContext
    {
        public TechstreamContext (DbContextOptions<TechstreamContext> options)
            : base(options)
        {
        }

        public DbSet<Techstream.Models.Employee> Employee { get; set; } = default!;
    }
}
