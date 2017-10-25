using System;
namespace DemoDAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
       
        int Complete();
    }
}
