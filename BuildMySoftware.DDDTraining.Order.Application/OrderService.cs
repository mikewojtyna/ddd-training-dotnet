using System.Collections.Generic;
using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;
        private readonly OrderFactory _factory;
        private readonly IEventPublisher _eventPublisher;

        public OrderService(IOrderRepository repository, OrderFactory factory, IEventPublisher eventPublisher)
        {
            _repository = repository;
            _factory = factory;
            _eventPublisher = eventPublisher;
        }

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order PlaceOrder()
        {
            var orderPlaced = _factory.placeOrder();
            _repository.save(orderPlaced.Order);
            _eventPublisher.publishEvent(orderPlaced);
            return orderPlaced.Order;
        }

        public void AddProductToOrder(Product product, OrderId orderId)
        {
            var order = _repository.findById(orderId);
            if (order == null) return;
            order.AddNewProduct(product);
            // we decided not to produce any interesting events when adding product to order
            _repository.save(order);
        }

        public Order OrderById(OrderId orderId)
        {
            return _repository.findById(orderId);
        }
    }
}