using System;
using System.Collections.Generic;
using System.Text;
using DemoDAL.Entities;
using DemoDAL.Context;
using System.Linq;

namespace DemoDAL.Repositories
{
    class ProductRepository : IProductRepository
    {
        public EASVContext _context;
        public ProductRepository(EASVContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            return product;
        }

        public Product Delete(int Id)
        {
            var product = Get(Id);
            _context.Products.Remove(product);
            return product;
        }

        public Product Get(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; };

            return _context.Products.Where(p => ids.Contains(p.Id));
        }
    }
}
