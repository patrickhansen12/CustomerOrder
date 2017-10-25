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

        private DALFacade _facade;

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
                var customerEntity = uow.CustomerRepository.Get(Id);
                return conv.Convert(customerEntity);
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
                customerEntity.FirstName = cust.FirstName;
                customerEntity.LastName = cust.LastName;
                customerEntity.Address = cust.Address;
                uow.Complete();
                return conv.Convert(customerEntity);
            }
        }
    }
}
