using System.Collections.Generic;

namespace DemoBLL.BusinessObjects
{
    public class CustomerBO : ICustomerBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<int> AddressIds { get; set; }
        public List<AddressBO> Addresses { get; set; }
    }
}
