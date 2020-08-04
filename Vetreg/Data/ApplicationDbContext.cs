using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vetreg.Models;

namespace Vetreg.Data {
    public class ApplicationDbContext : IdentityDbContext {

        public DbSet<Vetreg.Models.City> Cities { get; set; }
        public DbSet<Vetreg.Models.Region> Regions { get; set; }
        public DbSet<Vetreg.Models.Owner> Owners { get; set; }
        public DbSet<Vetreg.Models.Animal> Animals { get; set; }


        public DbSet<Vetreg.Models.Kind> Kinds { get; set; }
        public DbSet<Vetreg.Models.Breed> Breeds { get; set; }
        public DbSet<Vetreg.Models.Suit> Suits { get; set; }
        public DbSet<Vetreg.Models.Tag> Tags { get; set; }

        public DbSet<Vetreg.Models.Cause> Causes { get; set; }
        public DbSet<Vetreg.Models.Disease> Diseases { get; set; }
        public DbSet<Vetreg.Models.Work> Works { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkWithAnimal>()
                .HasKey(t => new { t.AnimalId, t.WorkId });

            modelBuilder.Entity<WorkWithAnimal>()
                .HasOne(sc => sc.Animal)
                .WithMany(s => s.WorksWithAnimal)
                .HasForeignKey(sc => sc.AnimalId);

            modelBuilder.Entity<WorkWithAnimal>()
                .HasOne(sc => sc.Work)
                .WithMany(c => c.WorksWithAnimal)
                .HasForeignKey(sc => sc.WorkId);
        }

        public DbSet<Vetreg.Models.Disease> Disease { get; set; }
    }
}
