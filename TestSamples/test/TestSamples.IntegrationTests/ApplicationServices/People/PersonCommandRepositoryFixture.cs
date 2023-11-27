using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Repositories;
using TestSamples.Infra.Data.Command.Sql;
using TestSamples.Infra.Data.Command.Sql.People;

namespace TestSamples.IntegrationTests.ApplicationServices.People
{
    public class PersonCommandRepositoryFixture:IDisposable
    {
        public IPersonCommandRepository personCommandRepository { get; }
        public TestSamplesDbContext dbContext { get; }

        public PersonCommandRepositoryFixture() 
        {
            DbContextOptionsBuilder<TestSamplesDbContext> builder = new DbContextOptionsBuilder<TestSamplesDbContext>();
            builder.UseSqlServer("Server=.;Database=PeopleIntegrationTest;User Id=sa;password=P@ssw0rd;TrustServerCertificate=True");
            dbContext = new TestSamplesDbContext(builder.Options);
            dbContext.Database.EnsureCreated();
            personCommandRepository = new EfPersonCommandRepository(dbContext);
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
