using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class OrderServiceIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlaceNewOrder()
        {
            // given
            DependencyContainer dependencyContainer = new DependencyContainer();
            var orderService = dependencyContainer.Resolve<OrderService>();

            // when
            var order = orderService.PlaceOrder();

            // then
            var savedOrder = orderService.OrderById(order.Id);
            Check.That(savedOrder).IsEqualTo(order);
        }
    }
}