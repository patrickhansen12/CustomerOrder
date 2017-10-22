using System;
using DemoDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DemoDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        // public ICustomerRepository CustomerRepository { get; internal set; }
        private EASVContext context;
        private static DbContextOptions<EASVContext> optionsStatic;
           
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

            //CustomerRepository = new CustomerRepository(context);
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
