using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Address : DomainObject
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }
    }
}
