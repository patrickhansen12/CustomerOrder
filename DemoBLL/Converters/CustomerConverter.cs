using DemoBLL.BusinessObjects;
using DemoDAL.Entities;

namespace DemoBLL.Converters
{
    public class CustomerConverter : IConverter<Customer, CustomerBO>
    {
        public Customer Convert(CustomerBO customer)
        {
            if (customer == null) { return null; }
            return new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address
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
                Address = customer.Address
            };
        }
    }
}
