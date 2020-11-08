using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Department : DomainObject
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int Funding { get; set; }
        
        public int ContactPhone { get; set; }
        
        public string ContactEmail { get; set; }
        
        public Address Address { get; set; }
        
        public List<Position> Positions { get; set; }
    }
}
