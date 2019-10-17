using BuildMySoftware.DDDTraining.Order;
using BuildMySoftware.DDDTraining.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using DBOrderRepository = BuildMySoftware.DDDTraining.Invoicing.Domain.IOrderRepository;

namespace BuildMySoftware.DDDTraining.Invoicing.Domain
{
    public class OrderEventPlacedConsumer : IEventConsumer
    {
        public DBOrderRepository repository;
        public void Consume(object domainEvent)
        {
            if (domainEvent is OrderPlaced op)
            {
                // create local order from OrderPlaced event
                repository.AddOrder(CreateOrder(op));
            }
            
        }
        private Order CreateOrder(OrderPlaced placedOrder)
        {
            return new Order();
        }
    }
}
