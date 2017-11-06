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

                var customer = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Rando",
                    LastName = "Persono",
                    Address = "Oveerdeer"
                });
                var customer2 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Arne",
                    LastName = "Olesen",
                    Address = "Danmarksgade 11"
                });
                var customer3 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Sidsel",
                    LastName = "Frandsen",
                    Address = "Havnegade 13"
                });
                var customer4 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Ulrik",
                    LastName = "Madsen",
                    Address = "Kirkegade 80"
                });
                var customer5 = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Hermann",
                    LastName = "Henningsen",
                    Address = "Strandby Kirkevej 50"
                });
                var order1 = facade.OrderService.Create(new OrderBO
                {
                    OrderDate = DateTime.Now.AddDays(-1),
                    DeliveryDate = DateTime.Now.AddDays(1),
                    Customer = customer3
                });
            }

            app.UseMvc();
        }
    }
}

