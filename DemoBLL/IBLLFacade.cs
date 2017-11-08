using DemoBLL.Services;
using System;
namespace DemoBLL
{
    public interface IBLLFacade
    {
        ICustomerService CustomerService { get; }
        IOrderService OrderService { get; }
        IAddressService AddressService { get; }
        IProductService ProductService { get; }

    }
}
