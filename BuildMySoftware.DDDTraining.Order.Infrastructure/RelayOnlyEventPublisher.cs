using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    public class RelayOnlyEventPublisher : IEventPublisher
    {
        private IDictionary<Type, List<IEventConsumer>> _consumers = new Dictionary<Type, List<IEventConsumer>>();

        public void RegisterConsumer<E>(IEventConsumer consumer)
        {
            var eventKey = typeof(E);
            if (_consumers.ContainsKey(eventKey))
            {
                _consumers[eventKey].Add(consumer);
            }
            else
            {
                _consumers[eventKey] = new List<IEventConsumer> {consumer};
            }
        }

        public void publishEvent(object domainEvent)
        {
            var key = domainEvent.GetType();
            if (!_consumers.ContainsKey(key)) return;
            var consumers = _consumers[key];
            consumers.ForEach(c => c.Consume(domainEvent));
        }
    }
}