using System;
using System.Collections.Generic;
using System.Text;
using DemoDAL.Entities;
using DemoDAL.Context;
using System.Linq;

namespace DemoDAL.Repositories
{
    class AddressRepository : IAddressRepository
    {
        EASVContext _context;
        public AddressRepository(EASVContext context)
        {
            _context = context;
        }

        public Address Create(Address address)
        {
            _context.Addresses.Add(address);
            return address;
        }

        public Address Delete(int Id)
        {
            var address = Get(Id);
            _context.Addresses.Remove(address);
            return address;
        }

        public Address Get(int Id)
        {
            return _context.Addresses.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public IEnumerable<Address> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; };

            return _context.Addresses.Where(a => ids.Contains(a.Id));
        }
    }
}
