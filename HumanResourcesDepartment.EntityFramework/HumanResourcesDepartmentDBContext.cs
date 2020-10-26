using HumanResourcesDepartment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.EntityFramework
{
    public class HumanResourcesDepartmentDBContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

