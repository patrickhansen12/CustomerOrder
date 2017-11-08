using DemoBLL.Converters;
using DemoDAL.Facade;
using System;
using System.Collections.Generic;
using System.Text;
using DemoBLL.BusinessObjects;
using System.Linq;

namespace DemoBLL.Services
{
    class CustomerService : ICustomerService
    {
        CustomerConverter conv = new CustomerConverter();
        OrderConverter oConv = new OrderConverter();
        AddressConverter aConv = new AddressConverter();

        private DALFacade _facade;

        public CustomerService(DALFacade _facade)
        {
            this._facade = _facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var customerEntity = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();
                return conv.Convert(customerEntity);
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var customerEntity = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(customerEntity);
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var cust = conv.Convert(uow.CustomerRepository.Get(Id));

                /*cust.Addresses = cust.AddressIds
                    .Select(id => aConv.Convert(uow.AddressRepository.Get(id)))
                    .ToList();*/

                cust.Addresses = uow.AddressRepository.GetAllById(cust.AddressIds)
                    .Select(a => aConv.Convert(a))
                    .ToList();

                return cust;
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var customerEntity = uow.CustomerRepository.Get(cust.Id);
                if (customerEntity == null)
                {
                    throw new InvalidOperationException("customer not found");
                }
                var customerUpdated = conv.Convert(cust);
                customerEntity.FirstName = customerUpdated.FirstName;
                customerEntity.LastName = customerUpdated.LastName;
                customerEntity.Addresses = customerUpdated.Addresses;

                uow.Complete();
                return conv.Convert(customerEntity);
            }
        }
    }
}
