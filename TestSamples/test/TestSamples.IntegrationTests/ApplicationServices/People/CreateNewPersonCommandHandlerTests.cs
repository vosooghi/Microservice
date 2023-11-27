using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.ApplicationService.People.CommandHandlers;
using TestSamples.ApplicationService.People.Commands;
using Xunit;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.IntegrationTests.ApplicationServices.People
{
    public class CreateNewPersonCommandHandlerTests : IClassFixture<PersonCommandRepositoryFixture>
    {
        private readonly PersonCommandRepositoryFixture fixture;

        public CreateNewPersonCommandHandlerTests(PersonCommandRepositoryFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void when_pass_valid_inputs_expect_person_created_and_registered_in_database()
        {
            //Arrange
            var command = new CreateNewPersonCommand
            {
                 FirstName="Abbas",
                 LastName="Vosoughi",
                 Id = Guid.NewGuid()
            };
            var handler = new CreateNewPersonCommandHandler(fixture.personCommandRepository);

            //Act
            handler.Handle(command);

            //Assert
            var person = fixture.dbContext.People.FirstOrDefault(w => w.BusinessId ==BusinessId.FromGuid(command.Id));
            person.ShouldNotBeNull();
            person.FirstName.ShouldBe(command.FirstName);
            person.LastName.ShouldBe(command.LastName);
        }
    }
}
