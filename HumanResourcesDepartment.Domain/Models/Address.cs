namespace HumanResourcesDepartment.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class Address : DomainObject
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
    }
}
