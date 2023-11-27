
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestSamples.ApplicationService.People.CommandHandlers;
using TestSamples.ApplicationService.People.Commands;
using TestSamples.Core.Domain.People.Entity;
using TestSamples.Core.Domain.People.Repositories;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController
    {
        private readonly ILogger<PersonController> logger;
        public PersonController(ILogger<PersonController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get([FromServices] IPersonCommandRepository repository, [FromQuery] Guid id)
        {
            logger.LogInformation($"run at {DateTime.Now}");
            Person person = repository.Get(BusinessId.FromGuid(id));
            
            return new OkObjectResult(new 
            { 
                FirstName = person.FirstName,
                LastName=person.LastName,
                Id = person.Id
            }) ;
        }
        [HttpPost]
        public IActionResult Post([FromServices] CreateNewPersonCommandHandler handler, [FromBody] CreateNewPersonCommand command)
        {
            handler.Handle(command);
            return new OkObjectResult(null);
        }
    }
}
