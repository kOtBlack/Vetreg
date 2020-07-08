using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vetreg.Models;

namespace Vetreg.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vetreg.Models.City> City { get; set; }
        public DbSet<Vetreg.Models.Region> Region { get; set; }
        public DbSet<Vetreg.Models.Breed> Breed { get; set; }
        public DbSet<Vetreg.Models.Suit> Suit { get; set; }
        public DbSet<Vetreg.Models.Tag> Tag { get; set; }
        public DbSet<Vetreg.Models.Kind> Kind { get; set; }
        public DbSet<Vetreg.Models.Owner> Owner { get; set; }
        public DbSet<Vetreg.Models.Animal> Animal { get; set; }
        public DbSet<Vetreg.Models.Company> Company { get; set; }
        public DbSet<Vetreg.Models.Work> Work { get; set; }
        public DbSet<Vetreg.Models.Cause> Cause { get; set; }
    }
}
