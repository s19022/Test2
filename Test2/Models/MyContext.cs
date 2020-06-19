using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class MyContext : DbContext
    {
        public DbSet<BreedType> BreedType { get; set; }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<Volunteer> Volunteer { get; set; }

        public DbSet<Volunteer_Pet> Volunteer_Pet { get; set; }

        public MyContext()
        {

        }

        public MyContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer_Pet>().HasKey(x => new { x.IdVolunteer, x.IdPet });
        }
    }
}
