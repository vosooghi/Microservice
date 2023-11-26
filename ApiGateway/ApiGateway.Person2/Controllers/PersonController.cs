using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Person2.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static readonly List<Person> people = new List<Person>
            {
                new Person
                {
                    Id =1,
                    FirstName="Abbas2",
                    LastName = "Vosoughi2"
                },
                                new Person
                {
                    Id =2,
                    FirstName="Radmehr2",
                    LastName = "Vosoughi2"
                },
                                                new Person
                {
                    Id =3,
                    FirstName="Elnaz2",
                    LastName = "Miraee2"
                }
            };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public Person Get(int id = 1)
        {
            return people.FirstOrDefault(c => c.Id == id);
        }
    }
}
