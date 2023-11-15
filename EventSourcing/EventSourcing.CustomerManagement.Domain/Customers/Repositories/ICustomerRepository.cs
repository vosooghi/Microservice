using EventSourcing.CustomerManagement.Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.Domain.Customers.Repositories
{
    public interface ICustomerRepository
    {
        Task<Guid> SaveAsync(Customer customer);
        Task<Customer> GetCustomer(Guid id);
    }
}
