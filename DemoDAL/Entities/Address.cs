using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    public class Address : IAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }

        public List<CustomerAddress> Customers { get; set; }
    }
}
