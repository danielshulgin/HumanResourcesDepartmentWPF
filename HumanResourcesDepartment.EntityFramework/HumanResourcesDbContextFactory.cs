using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.EntityFramework
{
    public class HumanResourcesDbContextFactory : IDesignTimeDbContextFactory<HumanResourcesDepartmentDBContext>
    {
        private readonly string _connectionString;


        public HumanResourcesDbContextFactory()
        {
            _connectionString = "server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;";
        }

        public HumanResourcesDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HumanResourcesDepartmentDBContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder<HumanResourcesDepartmentDBContext> options = new DbContextOptionsBuilder<HumanResourcesDepartmentDBContext>();

            options.UseSqlServer(_connectionString);
            return new HumanResourcesDepartmentDBContext(options.Options);
        }
    }
}
