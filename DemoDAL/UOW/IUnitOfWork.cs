﻿using DemoDAL.Repositories;
using System;
namespace DemoDAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IAddressRepository AddressRepository { get; }
        IProductRepository ProductRepository { get; }

        int Complete();
    }
}
