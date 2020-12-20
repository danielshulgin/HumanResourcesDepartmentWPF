using HumanResourcesDepartment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartment.EntityFramework
{
    public class HumanResourcesDepartmentDBContext : DbContext
    {
        public HumanResourcesDepartmentDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PreviousWorkPlace> PreviousWorkPlaces { get; set; }

        public DbSet<Profession> Professions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Department>(
             department =>
             {
                 department.Property(department => department.Name);
                 department.Property(department => department.Description);
                 department.Property(department => department.ContactPhone);
                 department.Property(department => department.ContactEmail);
             });

             modelBuilder.Entity<Address>(
             address =>
             {
                 address.Property(e => e.Country);
                 address.Property(e => e.City);
                 address.Property(e => e.Street);
                 address.Property(e => e.HouseNumber);
             });*/
            /*modelBuilder.Entity<Address>(address =>
            {
                address.Property(e => e.Country);
                address.Property(e => e.City);
                address.Property(e => e.Street);
                address.Property(e => e.HouseNumber);
            });*/
        }
    }
}

