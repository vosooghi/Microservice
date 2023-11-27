using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSamples.Core.Domain.People.Exceptions
{
    public class InvalidLastNameException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public InvalidLastNameException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
