﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Framework
{
    public interface IEventStore
    {
        Task SaveAsync(Guid aggregateId, string aggregateName, int originatingVersion, IReadOnlyCollection<IDomainEvent> events);

        Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(Guid aggregateRootId, string aggregateName);

        Task<IReadOnlyCollection<EventStoreItem>> GetAll(DateTime? afterDateTime);
    }
}
