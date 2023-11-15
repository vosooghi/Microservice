using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.CustomerManagement.ApplicationServices.Customers.Dtoes
{
    public class SaveCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
