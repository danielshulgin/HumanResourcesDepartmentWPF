using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Address : DomainObject, IEqualityComparer<Address>
    {
        public string Country { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string HouseNumber { get; private set; }


        public Address(string country, string city, string street, string houseNumber)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public bool Equals([AllowNull] Address x, [AllowNull] Address y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] Address obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
