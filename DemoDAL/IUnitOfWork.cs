using System;
namespace DemoDAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
       
        int Complete();
    }
}
