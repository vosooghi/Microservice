using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.ApplicationService.People.CommandHandlers;
using TestSamples.ApplicationService.People.Commands;
using TestSamples.Core.Domain.People.Entity;
using TestSamples.Core.Domain.People.Repositories;

namespace TestSamples.UnitTests.ApplicationService.People
{
    public class CreatNewPersonCommandHandlerTest
    {
        [Fact]
        public void when_pass_valid_input_expect_person_created_registered_in_database()
        {
            //Arrange
            var command = new CreateNewPersonCommand
            {
                FirstName = "Abbas",
                LastName = "Vosoughi",
                Id = Guid.NewGuid()
            };
            var moqRepo =new Mock<IPersonCommandRepository>();
            moqRepo.Setup(c => c.Add(It.IsAny<Person>()));
            var handler = new CreateNewPersonCommandHandler(moqRepo.Object);

            //Act
            handler.Handle(command);

            //Assert
            moqRepo.Verify(mock=>mock.Add(It.IsAny<Person>()),Times.Once);
        }
        

    }
}
