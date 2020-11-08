using HumanResourcesDepartment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.EntityFramework
{
    public class HumanResourcesDepartmentDBContext : DbContext
    {
        public HumanResourcesDepartmentDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PreviousWorkPlace> PreviousWorkPlaces { get; set; }

        public DbSet<Profession> Professions  { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

