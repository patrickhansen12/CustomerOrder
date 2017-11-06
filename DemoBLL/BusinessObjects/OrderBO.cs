using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBLL.BusinessObjects
{
    public class OrderBO : IOrderBO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int CustomerId { get; set; }
        public CustomerBO Customer { get; set; }
    }
}
