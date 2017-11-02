using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBLL.BusinessObjects
{
    interface ICustomerBO : IBusinessObject
    {
        String FirstName { get; set; }
        String LastName { get; set; }
        String Address { get; set; }
    }
}
