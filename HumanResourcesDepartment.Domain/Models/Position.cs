using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Position : DomainObject
    {
        public string Name { get; private set; }

        public Employee Employee { get; private set; }

        public Department Department { get; private set; }

        public Profession Profession { get; private set; }

        public int Salary { get; set; }


        public Position() { }

        public Position(string name, Employee employee, Profession profession, Department department, int salary)
        {
            Name = name;
            Employee = employee;
            Profession = profession;
            Department = department;
            Salary = salary;
        }

        public bool AddWorkerToPosition(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool RemoveWorkerFromPosition()
        {
            throw new NotImplementedException();
        }
    }
}
