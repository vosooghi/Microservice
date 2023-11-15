using EventSourcing.CustomerManagement.ApplicationServices.Customers.Dtoes;
using EventSourcing.CustomerManagement.Domain.Customers.Entities;
using EventSourcing.CustomerManagement.Domain.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.ApplicationServices.Customers
{
    /// <summary>
    /// Facade Controller, GRASP pattern.
    /// </summary>
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Guid> CreateCustomer(string firstName, string lastName)
        {
            var customer = Customer.CreateCustomer(firstName, lastName);
            var CustomerId = await _customerRepository.SaveAsync(customer);
            return CustomerId;
        }
        public async Task<Guid> UpdateCustomer(string CustomerId, string firstName, string lastName)
        {
            var customer = await _customerRepository.GetCustomer(Guid.Parse(CustomerId));
            customer.ChangeName(firstName, lastName);
            await _customerRepository.SaveAsync(customer);
            return customer.Id;
        }
        public async Task<CustomerDto> GetCustomer(string CustomerId)
        {
            var customer = await _customerRepository.GetCustomer(Guid.Parse(CustomerId));

            if (customer == null) return new CustomerDto(); // throw not found exception

            return new CustomerDto()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerId = customer.Id.ToString(),
                Address = customer.CustomerAddress != null ? new AddressDto()
                {
                    City = customer.CustomerAddress?.City,
                    Country = customer.CustomerAddress?.Country,
                    Street = customer.CustomerAddress?.Street,
                    ZipCode = customer.CustomerAddress?.ZipCode
                } : null
            };
        }
        public async Task UpdateAddress(string CustomerId, string city, string country, string street, string zipcode)
        {
            var customer = await _customerRepository.GetCustomer(Guid.Parse(CustomerId));

            if (customer == null) return;

            customer.ChangeAddress(street, country, zipcode, city);
            await _customerRepository.SaveAsync(customer);
        }

    }
}
