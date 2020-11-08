using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Profession : DomainObject
    {
        public int ProfessionCode { get; set; }

        public int AverageSalery { get; set; }

        public string Description { get; set; }
    }
}
