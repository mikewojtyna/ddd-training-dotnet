using BuildMySoftware.DDDTraining.SharedKernel;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Order.Domain.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateTotalCost()
        {
            // given
            var order = new Order();
            order.AddProduct(new Product(new Money(10.00m, "USD"), new ProductId("tea")));
            order.AddProduct(new Product(new Money(20.00m, "USD"), new ProductId("coffee")));

            // when
            var orderTotalCost = order.TotalCost;

            // then
            Check.That(orderTotalCost).IsEqualTo(new Money(30.00m, "USD"));
        }
    }
}