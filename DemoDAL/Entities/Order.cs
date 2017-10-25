using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    public class Order : IOrder
    {
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
