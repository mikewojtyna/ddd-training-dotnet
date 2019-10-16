using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BuildMySoftware.DDDTraining.Order
{
    public class InMemoryRepository : IOrderRepository
    {
        private readonly IDictionary<OrderId, Order> _orders = new ConcurrentDictionary<OrderId, Order>();

        public Order findById(OrderId id)
        {
            return _orders[id];
        }

        public void save(Order order)
        {
            _orders.Add(order.Id, order);
        }
    }
}