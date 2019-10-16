using System;
using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    public class OrderPlacedEventLogger : IEventConsumer
    {
        public void Consume(object domainEvent)
        {
            Console.WriteLine($"logging {domainEvent} in {nameof(OrderPlacedEventLogger)} consumer");
        }
    }
}