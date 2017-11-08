using System;
using System.Collections.Generic;
using System.Text;
using DemoBLL.BusinessObjects;
using DemoBLL.Converters;
using DemoDAL.Facade;
using System.Linq;

namespace DemoBLL.Services
{
    class AddressService : IAddressService
    {
        AddressConverter conv = new AddressConverter();
        private DALFacade _facade;

        public AddressService(DALFacade facade)
        {
            _facade = facade;
        }

        public AddressBO Create(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Create(conv.Convert(address));
                uow.Complete();
                return conv.Convert(addressEntity);
            }
        }

        public AddressBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(addressEntity);
            }
        }

        public AddressBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Get(Id);
                return conv.Convert(addressEntity);
            }
        }

        public List<AddressBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.AddressRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public AddressBO Update(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Get(address.Id);
                if (addressEntity == null)
                {
                    throw new InvalidOperationException("address not found");
                }
                addressEntity.City = address.City;
                addressEntity.Number = address.Number;
                addressEntity.Street = address.Street;
                uow.Complete();
                return conv.Convert(addressEntity);
            }
        }
    }
}
