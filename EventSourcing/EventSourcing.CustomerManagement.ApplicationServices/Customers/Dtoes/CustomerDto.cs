using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.ApplicationServices.Customers.Dtoes
{
    //We need to show customer object to end user in different structure and not as same as Customer object.
    public class CustomerDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerId { get; set; }

        public AddressDto Address { get; set; }
    }
}
