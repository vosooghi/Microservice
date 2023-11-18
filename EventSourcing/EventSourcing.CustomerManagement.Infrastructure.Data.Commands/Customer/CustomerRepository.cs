using EventSourcing.CustomerManagement.Domain.Customers.Repositories;
using EventSourcing.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcing.CustomerManagement.Domain.Customers.Entities;
namespace EventSourcing.CustomerManagement.Infrastructure.Data.Commands.Customer
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly IEventStore eventStore;

        public CustomerRepository(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        public async Task<EventSourcing.CustomerManagement.Domain.Customers.Entities.Customer> GetCustomer(Guid id)
        {
            var customerEvents = await eventStore.LoadAsync(id, typeof(EventSourcing.CustomerManagement.Domain.Customers.Entities.Customer).Name);
            return new EventSourcing.CustomerManagement.Domain.Customers.Entities.Customer(customerEvents);
        }

        public async Task<Guid> SaveAsync(EventSourcing.CustomerManagement.Domain.Customers.Entities.Customer customer)
        {
            await eventStore.SaveAsync(customer.Id, customer.GetType().Name, customer.Version, customer.DomainEvents);
            return customer.Id;
        }
    }
}
