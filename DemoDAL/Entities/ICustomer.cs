using DemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    interface ICustomer : IEntity
    {
        String FirstName { get; set; }
        String LastName { get; set; }
        String Address { get; set; }
    }
}
