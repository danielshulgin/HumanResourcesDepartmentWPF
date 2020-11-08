using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Worker : DomainObject
    {
        public string Name { get; set; }

        public Sex Sex { get; set; }

        public int Tin { get; set; }

        public int Phone { get; set; }

        public int ContactEmail { get; set; }

        public Address Address { get; set; }

        public List<PreviousWorkPlace> PreviousWorkPlaces { get; set; }
    }

    public enum Sex
    {
        Male, Female
    }
}
