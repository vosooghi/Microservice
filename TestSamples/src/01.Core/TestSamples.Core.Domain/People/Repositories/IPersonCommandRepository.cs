using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Entity;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.Core.Domain.People.Repositories
{
    public interface IPersonCommandRepository
    {
        void Add(Person person);
        Person Get(BusinessId businessId);
    }
}
