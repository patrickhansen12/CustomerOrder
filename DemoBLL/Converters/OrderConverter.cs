using DemoBLL.BusinessObjects;
using DemoDAL.Entities;

namespace DemoBLL.Converters
{
    public class OrderConverter : IConverter<Order, OrderBO>
    {

        public Order Convert(OrderBO order)
        {
            if (order == null) { return null; }
            return new Order()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.OrderDate,
                Customer = new CustomerConverter().Convert(order.Customer),
                CustomerId = order.CustomerId
            };
        }

        public OrderBO Convert(Order order)
        {
            if (order == null) { return null; }
            return new OrderBO()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Customer = new CustomerConverter().Convert(order.Customer),
                CustomerId = order.CustomerId
            };
        }
    }
}
