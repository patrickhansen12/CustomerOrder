using DemoBLL.Services;
using DemoDAL.Facade;

namespace DemoBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        /*private IDALFacade facade;

        public BLLFacade(IConfiguration conf){
            facade = new DALFacade(new DbOptions()
            {
                ConnectionString = conf.GetConnectionString("DefaultConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }*/

        public ICustomerService CustomerService
        {
            get { return new CustomerService(new DALFacade()); }
        }

        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade()); }
        }

        public IAddressService AddressService
        {
            get { return new AddressService(new DALFacade()); }
        }

        public IProductService ProductService
        {
            get { return new ProductService(new DALFacade());}
        }
    }
}
