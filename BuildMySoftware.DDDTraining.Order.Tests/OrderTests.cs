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
            Check.That(totalCost.IsZero()).IsTrue();
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

        [Test]
        public void Given_OrderWithSingleItemOfValueUSD10_When_AddNewItem_Then_TotalCostIsUpdated()
        {
            //Given
            Order order = OrderWithSingleProductOfPrice(OfUSD(10m));
            Product newProduct = ProductOfValue(OfUSD(68)); 
            //When
            order.AddNewProduct(newProduct);
            //Then
            Check.That(order.CalculateTotalCost()).IsEqualTo(OfUSD(78m));
        }

        [Test]
        public void Given_EmptyOrder_When_AddTwoNewItems_Then_TotalCostIsSumOfThoseItems()
        {
            //Given
            Order order = EmptyOrder();
            Product newProduct1 = ProductOfValue(OfUSD(10));
            Product newProduct2 = ProductOfValue(OfUSD(20));
            //When
            order.AddNewProduct(newProduct1);
            order.AddNewProduct(newProduct2);
            //Then
            Check.That(order.CalculateTotalCost()).IsEqualTo(OfUSD(30m));
        }

        [Test]
        public void Given_OrderWithSingleItemOfValueUSD10AndMaxTotalCostOf20_When_AddNewItemOfValue11USD_Then_Fail()
        {
            //Given
            Order order = OrderWithSingleProductOfPriceAndMaxTotalCost(OfUSD(10m), OfUSD(20m));
            Product newProduct = ProductOfValue(OfUSD(11m));
            //When
            Check.ThatCode(() => order.AddNewProduct(newProduct))
                // then
                .Throws<OrderMaxTotalCostExceeded>();
            //Then
            // nothing changed
            Check.That(order.CalculateTotalCost()).IsEqualTo(OfUSD(10m));
        }

        private Order OrderWithSingleProductOfPriceAndMaxTotalCost(Money productPrice           , Money limit)
        {
            Order order = new Order(OrderLimit.LimitedBy(limit));
            order.AddNewProduct(ProductOfValue(productPrice));
            return order;
        }

        private Product ProductOfValue(Money money)
        {
            return new Product(money);
        }

        private Order OrderWithSingleProductOfPrice(Money money)
        {
            return Order.WithProducts(new Product(money));
        }

        private Money OfUSD(decimal amount)
        {
            return Money.Of(amount, CurrencyUnit.USD);
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
