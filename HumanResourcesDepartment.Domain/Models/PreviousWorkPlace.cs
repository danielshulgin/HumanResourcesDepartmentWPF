using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class PreviousWorkPlace : DomainObject
    {
        public Profession Profession { get; set; }

        public DateTime InstallationDate { get; set; }

        public DateTime ReliseDate { get; set; }
    }
}
