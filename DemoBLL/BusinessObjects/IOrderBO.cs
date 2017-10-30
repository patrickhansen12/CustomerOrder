using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBLL.BusinessObjects
{
    interface IOrderBO : IBusinessObject
    {
        DateTime OrderDate { get; set; }
        DateTime DeliveryDate { get; set; }
    }
}
