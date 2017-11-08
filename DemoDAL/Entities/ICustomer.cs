using System;

namespace DemoDAL.Entities
{
    interface ICustomer : IEntity
    {
        String FirstName { get; set; }
        String LastName { get; set; }
    }
}
