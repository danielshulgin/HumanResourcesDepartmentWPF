using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Department : DomainObject
    {
        public string Name { get; private set; }
        
        public string Description { get; private set; }
        
        public int ContactPhone { get; private set; }
        
        public string ContactEmail { get; private set; }
        
        public Address Address { get; private set; }


        public Department() { }

        public Department(string name, string description, int contactPhone, string contactEmail, Address address)
        {
            Name = name;
            Description = description;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
            Address = address;
        }
    }
}
