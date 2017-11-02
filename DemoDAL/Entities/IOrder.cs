using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    interface IOrder : IEntity
    {
        DateTime OrderDate { get; set; }
        DateTime DeliveryDate { get; set; }
    }
}
