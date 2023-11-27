using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Entity;
using TestSamples.Infra.Data.Command.Sql.People;

namespace TestSamples.Infra.Data.Command.Sql
{
    public class TestSamplesDbContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public TestSamplesDbContext(DbContextOptions<TestSamplesDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
