using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSamples.Core.Domain.People.Exceptions
{
    public class InvalidPersonIdException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public InvalidPersonIdException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
