using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSamples.ApplicationService.People.Commands
{
    public class CreateNewPersonCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
    }
}
