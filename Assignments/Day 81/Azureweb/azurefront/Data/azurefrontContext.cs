using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using azurefront.Models;

namespace azurefront.Data
{
    public class azurefrontContext : DbContext
    {
        public azurefrontContext (DbContextOptions<azurefrontContext> options)
            : base(options)
        {
        }

        public DbSet<azurefront.Models.student> student { get; set; } = default!;
    }
}
