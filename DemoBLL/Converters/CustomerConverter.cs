using DemoBLL.BusinessObjects;
using DemoDAL.Entities;
using System.Linq;

namespace DemoBLL.Converters
{
    public class CustomerConverter : IConverter<Customer, CustomerBO>
    {
        private AddressConverter aConv;

        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }

        public Customer Convert(CustomerBO customer)
        {
            if (customer == null) { return null; }
            return new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Addresses = customer.AddressIds?.Select(aId => new CustomerAddress()
                {
                    AddressId = aId,
                    CustomerId = customer.Id
                }).ToList()
            };
        }

        public CustomerBO Convert(Customer customer)
        {
            if (customer == null) { return null; }
            return new CustomerBO()
            {
                Id = customer.Id,
                AddressIds = customer.Addresses?.Select(a => a.AddressId).ToList(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }
    }
}
