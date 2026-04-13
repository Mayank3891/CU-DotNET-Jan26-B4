using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webback.Models;

namespace webback.Data
{
    public class webbackContext : DbContext
    {
        public webbackContext (DbContextOptions<webbackContext> options)
            : base(options)
        {
        }

        public DbSet<webback.Models.student> student { get; set; } = default!;
    }
}
