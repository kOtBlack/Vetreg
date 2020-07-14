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
        public DbSet<Vetreg.Models.City> Cities { get; set; }
        public DbSet<Vetreg.Models.Region> Regions { get; set; }
        public DbSet<Vetreg.Models.Owner> Owners { get; set; }
        public DbSet<Vetreg.Models.Animal> Animals { get; set; }


        public DbSet<Vetreg.Models.Kind> Kinds { get; set; }
        public DbSet<Vetreg.Models.Breed> Breeds { get; set; }
        public DbSet<Vetreg.Models.Suit> Suits { get; set; }
        public DbSet<Vetreg.Models.Tag> Tags { get; set; }


        public DbSet<Vetreg.Models.Cause> Causes { get; set; }




    }
}
