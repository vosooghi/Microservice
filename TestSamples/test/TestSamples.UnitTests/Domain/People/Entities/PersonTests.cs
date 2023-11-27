using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Entity;
using TestSamples.Core.Domain.People.Events;
using TestSamples.Core.Domain.People.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.UnitTests.Domain.People.Entities
{
  
    public class PersonTests
    {
        [Fact]
        public void when_pass_correct_values_to_factory_person_created()
        {
            //Arrange
            string firstName = "Abbas";
            string lastName = "Vosoughi";
            BusinessId businessId = BusinessId.FromGuid(Guid.NewGuid());
            //Act
            var person = Person.Create(businessId,firstName, lastName);
            //Assert
            person.ShouldNotBeNull();
            person.FirstName.ShouldNotBeNull();
            person.LastName.ShouldNotBeNull();
            person.FirstName.ShouldBe(firstName);
            person.LastName.ShouldBe(lastName);
            var @event = person.GetEvents().FirstOrDefault();
            @event.ShouldBeOfType<PersonCreated>();
            //person.Id.ShouldBe(businessId);
        }

        [Fact]
        public void When_pass_invalid_businessId_to_factory_expect_invalidPersonIdExpection()
        {
            //Arrange
            string firstName = "Abbas";
            string lastName = "Vosoughi";
            BusinessId businessId = BusinessId.FromGuid(Guid.NewGuid());

            //Act
            var invalidPersonIdException = Record.Exception(()=>Person.Create(businessId, firstName, lastName));

            //Assert
            invalidPersonIdException.ShouldNotBeNull();
            invalidPersonIdException.ShouldBeOfType<InvalidPersonIdException>();
        }
    }
}
