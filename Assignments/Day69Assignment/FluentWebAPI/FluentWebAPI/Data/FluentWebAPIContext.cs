using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentWebAPI.Models;

namespace FluentWebAPI.Data
{
    public class FluentWebAPIContext : DbContext
    {
        public FluentWebAPIContext (DbContextOptions<FluentWebAPIContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                .IsRequired().HasMaxLength(100);

                entity.HasIndex(s => s.Email)
                .IsUnique();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                .IsRequired();
            });
        }

        public DbSet<FluentWebAPI.Models.Student> Student { get; set; } = default!;
        public DbSet<FluentWebAPI.Models.Course> Course { get; set; } = default!;
    }
}
