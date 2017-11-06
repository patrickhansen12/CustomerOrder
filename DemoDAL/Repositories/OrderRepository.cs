using DemoDAL.Context;
using DemoDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        EASVContext _context;
        public OrderRepository(EASVContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            if (order.Customer != null)
            {
                _context.Entry(order.Customer).State =
                    EntityState.Unchanged;
            }
            _context.Orders.Add(order);
            return order;
        }

        public Order Delete(int Id)
        {
            var order = Get(Id);
            _context.Orders.Remove(order);
            return order;
        }

        public Order Get(int Id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; };

            return _context.Orders.Where(o => ids.Contains(o.Id));
        }
    }
}
