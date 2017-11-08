using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBLL.BusinessObjects
{
    public class AddressBO : IAddressBO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
    }
}
