using BuildMySoftware.DDDTraining.SharedKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BuildMySoftware.DDDTraining.Order
{
    public class DependencyContainer
    {
        private WindsorContainer _windsorContainer;

        public DependencyContainer()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Register(Component.For<OrderService>());
            _windsorContainer.Register(Component.For<IOrderRepository>().ImplementedBy<InMemoryRepository>());
            _windsorContainer.Register(Component.For<OrderFactory>());
            RelayOnlyEventPublisher eventPublisher = new RelayOnlyEventPublisher();
            eventPublisher.RegisterConsumer<OrderPlaced>(new OrderPlacedEventLogger());
            _windsorContainer.Register(Component.For<IEventPublisher>().Instance(eventPublisher));
        }

        public T Resolve<T>()
        {
            return _windsorContainer.Resolve<T>();
        }
    }
}