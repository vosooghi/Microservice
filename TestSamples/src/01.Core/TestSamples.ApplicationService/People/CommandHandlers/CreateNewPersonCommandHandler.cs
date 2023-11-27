using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.ApplicationService.People.Commands;
using TestSamples.Core.Domain.People.Entity;
using TestSamples.Core.Domain.People.Repositories;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.ApplicationService.People.CommandHandlers
{
    public class CreateNewPersonCommandHandler
    {
        private readonly IPersonCommandRepository _repository;

        public CreateNewPersonCommandHandler(IPersonCommandRepository repository) {
            _repository = repository;
        }
        public void Handle(CreateNewPersonCommand command) {
        var person = Person.Create(BusinessId.FromGuid(command.Id),command.FirstName,command.LastName);
            _repository.Add(person);
        }
    }
}
