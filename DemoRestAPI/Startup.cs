using DemoBLL;
using DemoBLL.BusinessObjects;
using DemoBLL.Facade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
				builder.WithOrigins("http://localhost:4200")
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

            services.AddSingleton(Configuration);
            services.AddScoped<IBLLFacade, BLLFacade>();
        
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
				loggerFactory.AddConsole(Configuration.GetSection("Logging"));
				loggerFactory.AddDebug();

				app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                var address = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Esbjerg",
                        Street = "Niels Bohrs vej",
                        Number = "14"
                    });

                var customer = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Rando",
                    LastName = "Persono",
                    AddressIds = new List<int>() { address.Id }
                });
                var customer2 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Arne",
                    LastName = "Olesen",
                    AddressIds = new List<int>() { address.Id }
                });
                var customer3 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Sidsel",
                    LastName = "Frandsen",
                    AddressIds = new List<int>() { address.Id }
                });
                var customer4 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Ulrik",
                    LastName = "Madsen",
                    AddressIds = new List<int>() { address.Id }
                });
                var customer5 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Hermann",
                    LastName = "Henningsen",
                    AddressIds = new List<int>() { address.Id }
                });
                var order1 = facade.OrderService.Create(new OrderBO
                {
                    OrderDate = DateTime.Now.AddDays(-1),
                    DeliveryDate = DateTime.Now.AddDays(1),
                    CustomerId = customer.Id
                });
            }

            app.UseMvc();
        }
    }
}

