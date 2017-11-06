using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBLL.BusinessObjects
{
    interface IProductBO : IBusinessObject
    {
        String Name { get; set; }
    }
}
