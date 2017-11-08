using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public List<CustomerAddress> Addresses { get; set; }

        public List<Order> Orders { get; set; }
    }
}
