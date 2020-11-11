using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Models
{
    public class ApplicationContext: DbContext 
    {
        public DbSet<Homeless> Homelesses { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Service> Services { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.EnsureCreated();
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=VolunteerCompany;Username=postgres;Password=1q2w3e4r5t6y");
        }

    }
}
