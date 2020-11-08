using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Department> workerService = new GenericDataService<Department>(new HumanResourcesDbContextFactory("server=(localdb)\\MSSQLLocalDB;Database=HumanResourcesDepartmentDB;Trusted_Connection=True;"));
            Console.WriteLine(workerService.GetAll().Result.First().Name);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
