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
                DeliveryDate = order.OrderDate
            };
        }

        public OrderBO Convert(Order order)
        {
            if (order == null) { return null; }
            return new OrderBO()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate
            };
        }
    }
}
