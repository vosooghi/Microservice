using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Events;

namespace TestSamples.Core.Domain.People.Events
{
    public class PersonCreated : IDomainEvent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Id { get; }

        public PersonCreated(Guid id, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id.ToString();

        }
    }

}
