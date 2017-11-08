using System;
using DemoDAL.Context;
using Microsoft.EntityFrameworkCore;
using DemoDAL.Repositories;

namespace DemoDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        public IAddressRepository AddressRepository { get; internal set; }
        public IProductRepository ProductRepository { get; internal set; }

        private EASVContext context;
        /*private static DbContextOptions<EASVContext> optionsStatic;
           
        public UnitOfWork(DbOptions opt)
        {
             if(opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString)){
                optionsStatic = new DbContextOptionsBuilder<EASVContext>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;
                context = new EASVContext(optionsStatic);
            }
            else{
                var options = new DbContextOptionsBuilder<EASVContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
                context = new EASVContext(options);
            }

            CustomerRepository = new CustomerRepository(context);
        }*/

        public UnitOfWork()
        {
            context = new EASVContext();
            context.Database.EnsureCreated();
            CustomerRepository = new CustomerRepository(context);
            OrderRepository = new OrderRepository(context);
            ProductRepository = new ProductRepository(context);
            AddressRepository = new AddressRepository(context);

        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
