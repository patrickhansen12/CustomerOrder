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
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.AddressId, ca.CustomerId });

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.CustomerId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}