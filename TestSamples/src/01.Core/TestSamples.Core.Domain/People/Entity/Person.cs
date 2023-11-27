using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Events;
using TestSamples.Core.Domain.People.Exceptions;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Core.Domain.Events;

namespace TestSamples.Core.Domain.People.Entity
{
    public class Person:AggregateRoot
    {
        public int PersonId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        private Person() { }

        public static Person Create(BusinessId id, string firstName, string lastName)
        {
            if (id == null)
            {
                throw new InvalidPersonIdException("PersonIdIsNull");
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new InvalidFirstNameException("FirstNameIsNull");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new InvalidLastNameException("LastNameIsNull");

            }


            var person = new Person
            { 
                BusinessId = id,
                FirstName = firstName,
                LastName = lastName
            };
            person.AddEvent(new PersonCreated(person.BusinessId.Value, person.FirstName, person.LastName));
            return person;
        }
    }
}
