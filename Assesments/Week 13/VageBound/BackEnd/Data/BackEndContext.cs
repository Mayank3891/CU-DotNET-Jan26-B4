using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Data
{
    public class BackEndContext : DbContext
    {
        public BackEndContext (DbContextOptions<BackEndContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Destination>(entity=>{
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CityName).IsRequired();
                entity.Property(e => e.Country).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.Rating).HasDefaultValue(3);

            }
              )  ;

        }

        public DbSet<BackEnd.Models.Destination> Destination { get; set; } = default!;
    }
}
