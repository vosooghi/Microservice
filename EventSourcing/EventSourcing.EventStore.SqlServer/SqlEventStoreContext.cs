using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.EventStore.SqlServer
{
    public class SqlEventStoreContext:DbContext
    {

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EventStoreData>().Property(b => b.Sequence).ValueGeneratedOnAdd();                
        //}
    }

   
}
