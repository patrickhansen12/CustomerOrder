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
                Addresses = customer.Addresses?.Select(a => new CustomerAddress()
                {
                    AddressId = a.Id,
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
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Addresses = customer.Addresses?.Select( a => new AddressBO()
                {
                    Id = a.CustomerId,
                    City = a.Address?.City,
                    Number = a.Address?.Number,
                    Street = a.Address?.Street
                }).ToList()
            };
        }
    }
}
