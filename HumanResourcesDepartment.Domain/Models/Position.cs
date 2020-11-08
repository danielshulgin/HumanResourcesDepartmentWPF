using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Position : DomainObject
    {
        public Worker Worker { get; set; }

        public Profession Profession { get; set; }

        public int Salary { get; set; }
    }
}
