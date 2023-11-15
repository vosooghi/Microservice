﻿using EventSourcing.CustomerManagement.Domain.Customers.Events;
using EventSourcing.CustomerManagement.Domain.Customers.ValueObjects;
using EventSourcing.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.Domain.Customers.Entities
{
    public class Customer:AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address CustomerAddress { get; private set; }

        public Customer(IEnumerable<IDomainEvent> events) : base(events)
        {
        }

        private Customer()
        {

        }
        /// <summary>
        /// Factory Pattern
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static Customer CreateCustomer(
            string firstName,
            string lastName)
        {
            //Business Logic
            var customer = new Customer();

            customer.Apply(new CustomerCreated(Guid.NewGuid().ToString(), firstName, lastName));
            return customer;
        }
        public void ChangeName(string firstName, string lastName)
        {
            Apply(new CustomerNameChanged(Id.ToString(), firstName, lastName));
        }
        public void ChangeAddress(string street, string country, string zipCode, string city)
        {
            Apply(new AddressChanged(Id.ToString(), city, country, zipCode, street));
        }



        public void On(CustomerCreated @event)
        {
            Id = Guid.Parse(@event.CustomerId);
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        }

        public void On(CustomerNameChanged @event)
        {
            Id = Guid.Parse(@event.CustomerId);
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        }

        public void On(AddressChanged @event)
        {

            CustomerAddress = new Address()
            {
                City = @event.City,
                Country = @event.Country,
                Street = @event.Street,
                ZipCode = @event.ZipCode
            };
        }
    }
}
