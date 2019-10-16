using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    class OrderTests
    {
        [Test]
        public void Given_EmptyOrder_WhenCalculateTotalCost_Then_TotalCOstIsZero()
        {
            //Given
            var order = EmptyOrder();
            //When
            Money totalCost = order.CalculateTotalCost();
            //Then
            Check.That(totalCost).IsEqualTo(ZeroDollars());
        }

        [Test]
        public void Given_OrderWithSingleItemOfValueUSD10_WhenCalculatingTotalCost_TotalCostIsExactlyUSD10()
        {
            //Given
            Order order = OrderWithSingleProductOfPrice(OfUSD(10m));
            //When
            Money totalCost = order.CalculateTotalCost();
            //Then
            Check.That(totalCost).IsEqualTo(OfUSD(10m));
        }

        private Order OrderWithSingleProductOfPrice(Money money)
        {
            return Order.WithProducts(new Product(money));
        }

        private Money OfUSD(decimal amount)
        {
            return Money.Of(10, CurrencyUnit.USD);
        }

        private object OrderWithSingleItem()
        {
            throw new NotImplementedException();
        }

        private Order EmptyOrder()
        {
            return new Order();
        }

        private Money ZeroDollars()
        {
            return Money.Of(0, CurrencyUnit.USD);
        }
    }
}
