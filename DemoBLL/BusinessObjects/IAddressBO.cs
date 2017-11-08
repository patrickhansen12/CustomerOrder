using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBLL.BusinessObjects
{
    interface IAddressBO : IBusinessObject
    {
        String Street { get; set; }
        String Number { get; set; }
        String City { get; set; }
    }
}
