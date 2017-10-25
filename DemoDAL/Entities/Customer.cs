﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    class Customer : ICustomer
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Address { get; set; }
    }
}
