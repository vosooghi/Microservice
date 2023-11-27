﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSamples.Core.Domain.People.Exceptions
{
    public class PersonTagsNullException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public PersonTagsNullException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
