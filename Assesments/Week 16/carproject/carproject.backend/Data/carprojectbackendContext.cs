using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using carproject.backend.Model;

namespace carproject.backend.Data
{
    public class carprojectbackendContext : DbContext
    {
        public carprojectbackendContext (DbContextOptions<carprojectbackendContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Cars");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Price)
                    .HasPrecision(18, 2);

                entity.Property(c => c.FuelType)
                    .HasMaxLength(20);

                entity.Property(c => c.IsAvailable)
                    .HasDefaultValue(true);
            });
        }
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<carproject.backend.Model.Car> Car { get; set; } = default!;
    }
}
