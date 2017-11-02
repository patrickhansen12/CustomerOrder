using System;
using System.Collections.Generic;
using System.Text;
using DemoDAL.Entities;
using DemoDAL.Context;
using System.Linq;

namespace DemoDAL.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        EASVContext _context;
        public CustomerRepository(EASVContext context)
        {
            _context = context;
        }

        public Customer Create(Customer cust)
        {
            _context.Customers.Add(cust);
            return cust;
        }

        public Customer Delete(int Id)
        {
            var customer = Get(Id);
            _context.Customers.Remove(customer);
            return customer;
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Customer> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; };

            return _context.Customers.Where(c => ids.Contains(c.Id));
        }
    }
}
