using DemoBLL.Services;
using System;
namespace DemoBLL
{
    public interface IBLLFacade
    {
        ICustomerService CustomerService { get; }
    }
}
