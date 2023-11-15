using EventSourcing.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.Domain.Customers.Events
{
    public class AddressChanged:IDomainEvent
    {
        public string City { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public string Street { get; }
        public string CustomerId { get; }
        public AddressChanged(string customerId,
            string city,
            string country,
            string zipcode,
            string street)
        {
            CustomerId = customerId;
            City = city;
            Country = country;
            ZipCode = zipcode;
            Street = street;
        }
    }
}
