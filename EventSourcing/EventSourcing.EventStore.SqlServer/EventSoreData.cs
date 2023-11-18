using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.EventStore.SqlServer
{
    public class EventStoreData
    {
        [Key]
        public Guid Id { get; set; }
        [NotNull]
        public DateTime CreatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sequence {  get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string AggregateId { get; set; }
        public string Data { get; set; }
        public string Aggregate {  get; set; }
    }
}
/*
 ﻿CREATE TABLE [dbo].[EventStore](
[Id] [uniqueidentifier] NOT NULL,
[CreatedAt] [datetime2] NOT NULL,
[Sequence] [int] IDENTITY(1,1) NOT NULL,
[Version] [int] NOT NULL,
[Name] [nvarchar](250) NOT NULL,
[AggregateId] [nvarchar](250) NOT NULL,
[Data] [nvarchar](max) NOT NULL,
[Aggregate] [nvarchar](250) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
 */