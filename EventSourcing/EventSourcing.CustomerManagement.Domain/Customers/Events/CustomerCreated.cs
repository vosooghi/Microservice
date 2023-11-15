using EventSourcing.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.Domain.Customers.Events
{
    public class CustomerCreated:IDomainEvent
    {
        //we shouldn't define setters, for events are immutable.
        public string CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public CustomerCreated(
            string customerId,
            string firstName,
            string lastName)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
