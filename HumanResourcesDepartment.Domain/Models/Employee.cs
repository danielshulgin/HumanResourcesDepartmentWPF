using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Employee : DomainObject
    {
        public string Name { get; private set; }

        public Sex Sex { get; private set; }

        public int Tin { get; private set; }

        public int Phone { get; private set; }

        public string ContactEmail { get; private set; }

        public Address Address { get;  set; }

        public IEnumerable<PreviousWorkPlace> PreviousWorkPlaces { get; private set; }


        public Employee() { }

        public Employee(string name, Sex sex, int tin, int phone, string contactEmail, Address address, List<PreviousWorkPlace> previousWorkPlaces)
        {
            Name = name;
            Sex = sex;
            Tin = tin;
            Phone = phone;
            ContactEmail = contactEmail;
            Address = address;
            PreviousWorkPlaces = previousWorkPlaces;
        }

        public void AddPreviousWorkPlace(PreviousWorkPlace previousWorkPlace)
        {
            throw new NotImplementedException();
        }
    }

    public enum Sex
    {
        Male, Female
    }
}
