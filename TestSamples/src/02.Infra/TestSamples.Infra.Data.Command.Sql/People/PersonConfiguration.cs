using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamples.Core.Domain.People.Entity;
using Zamin.Core.Domain.ValueObjects;

namespace TestSamples.Infra.Data.Command.Sql.People
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.BusinessId).HasConversion(c => c.Value,c=> BusinessId.FromGuid(c));
        }
    }
}
