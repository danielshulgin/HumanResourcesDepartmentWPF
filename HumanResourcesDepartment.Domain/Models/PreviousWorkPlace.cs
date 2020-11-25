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

        public PreviousWorkPlace() { }

        public PreviousWorkPlace(Profession profession, DateTime installationDate, DateTime reliseDate)
        {
            Profession = profession;
            InstallationDate = installationDate;
            ReliseDate = reliseDate;
        }
    }
}
