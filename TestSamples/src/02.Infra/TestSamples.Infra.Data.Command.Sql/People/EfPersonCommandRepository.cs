using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Entity;
using TestSamples.Core.Domain.People.Repositories;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.Infra.Data.Command.Sql.People
{
    public class EfPersonCommandRepository : IPersonCommandRepository
    {
        private readonly TestSamplesDbContext _testSamplesDbContext;

        public EfPersonCommandRepository(TestSamplesDbContext testSamplesDbContext)
        {
            _testSamplesDbContext = testSamplesDbContext;
        }
        public void Add(Person person)
        {
            _testSamplesDbContext.People.Add(person);
            _testSamplesDbContext.SaveChanges();
        }

        public Person Get(BusinessId businessId)
        {
            //this is a query, so we should write this in Query repository.
            return _testSamplesDbContext.People.SingleOrDefault(w=>w.BusinessId ==businessId);
        }
    }
}
