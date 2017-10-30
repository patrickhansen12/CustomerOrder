using DemoDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoDAL.Context
{
    class EASVContext : DbContext
    {
        static DbContextOptions<EASVContext> options =
            new DbContextOptionsBuilder<EASVContext>()
                .UseInMemoryDatabase("TheDB").Options;

        public EASVContext() : base(options) { }
        //public EASVContext(DbContextOptions<EASVContext> options): base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}