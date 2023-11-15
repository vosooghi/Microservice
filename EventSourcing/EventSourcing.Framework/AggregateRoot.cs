using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Framework
{
    public class AggregateRoot : Entity
    {
        /// <summary>
        /// By each command,the version of Aggregate changes.
        /// </summary>
        public int Version { get; private set; }

        //domain events shouldn't be changed by others.
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        protected AggregateRoot() { }

        protected void AddDomainEvent(IDomainEvent @event) =>
            _domainEvents.Add(@event);

        protected void RemoveDomainEvent(IDomainEvent @event) =>
            _domainEvents.Remove(@event);

        protected void ClearDomainEvents() =>
            _domainEvents.Clear();

        public IReadOnlyCollection<IDomainEvent> DomainEvents =>
            _domainEvents.AsReadOnly();

        /// <summary>
        /// fetch saved events from DB
        /// </summary>
        /// <param name="events"></param>
        public AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            if (events == null) return;

            foreach (var domainEvent in events)
            {
                Mutate(domainEvent);
                Version++;
            }
        }

        
        protected void Apply(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                Apply(@event);
            }
        }
        /// <summary>
        /// When an event is not saved in DB, this method is callled.
        /// </summary>
        /// <param name="event"></param>
        protected void Apply(IDomainEvent @event)
        {
            //Rise the relevant event
            Mutate(@event);
            AddDomainEvent(@event);
        }

        private void Mutate(IDomainEvent @event) => ((dynamic)this).On((dynamic)@event);
    }
}
