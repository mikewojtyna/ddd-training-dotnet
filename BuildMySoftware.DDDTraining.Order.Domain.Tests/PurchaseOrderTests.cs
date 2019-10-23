using System;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class PurchaseOrderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_EmptyOrder_Then_TotalCostIsZero()
        {
            // given
            PurchaseOrder purchaseOrder = EmptyOrder();

            // when
            Money totalCost = purchaseOrder.TotalCost();

            // then
            Check.That(totalCost).IsEqualTo(Zero());
        }

        [Test]
        public void Given_OrderWithSingleProductOfValue10USD_Then_TotalCostIs10USD()
        {
            // given
            PurchaseOrder purchaseOrder = EmptyOrder();
            Product product = ProductWithPrice(Usd(10.00m));
            purchaseOrder.AddProduct(product);

            // when
            var totalCost = purchaseOrder.TotalCost();

            // then
            Check.That(totalCost).IsEqualTo(Usd(10.00m));
        }

        [Test]
        public void Given_OrderWithTwoProductsOfValues10UsdAnd20Usd_Then_TotalCostIs30Usd()
        {
            // given
            PurchaseOrder purchaseOrder = EmptyOrder();
            Product tea = ProductWithPriceAndName(Usd(10.00m), "tea");
            Product coffee = ProductWithPriceAndName(Usd(20.00m), "coffee");
            purchaseOrder.AddProduct(tea);
            purchaseOrder.AddProduct(coffee);

            // when
            var totalCost = purchaseOrder.TotalCost();

            // then
            Check.That(totalCost).IsEqualTo(Usd(30.00m));
        }

        [Test]
        public void Given_PurchaseOrderWithMaxTotalCost100Usd_When_TryToAddNewItemOver100Usd_ThenAddFails()
        {
            // given
            PurchaseOrder purchaseOrder = EmptyOrderWithMaxTotalCostOf(Usd(100.00m));
            Product product = ProductWithPrice(Usd(101.00m));

            // when
            Check.ThatCode(() => purchaseOrder.AddProduct(product))

                // then
                .Throws<MaxTotalCostExceeded>();
        }

        [Test]
        public void Given_PurchaseOrder_ThenCannotAddMoreThan3TheSameProducts()
        {
            // given
            PurchaseOrder purchaseOrder = EmptyOrder();
            Product tea = ProductWithName("tea");

            // when
            purchaseOrder.AddProduct(tea);
            purchaseOrder.AddProduct(tea);
            purchaseOrder.AddProduct(tea);
            Check.ThatCode(() => purchaseOrder.AddProduct(tea))

                // then
                .Throws<MaxProductQuantityExceeded>();
        }

        private Product ProductWithName(string name)
        {
            return new Product(Zero(), name);
        }

        private PurchaseOrder EmptyOrderWithMaxTotalCostOf(Money amount)
        {
            MaxTotalCost maxTotalCost = new MaxTotalCost(amount);
            return new PurchaseOrder(GenerateId(), maxTotalCost);
        }

        private PurchaseOrderId GenerateId()
        {
            return new PurchaseOrderId(Guid.NewGuid());
        }

        private Product ProductWithPriceAndName(Money amount, string product)
        {
            return new Product(amount, product);
        }

        private Product ProductWithPrice(Money money)
        {
            return new Product(money, DefaultProductName());
        }

        private string DefaultProductName()
        {
            return "tea";
        }

        private Money Usd(decimal amount)
        {
            return Money.Of(amount, "USD");
        }

        private Money Zero()
        {
            return Money.Zero();
        }

        private PurchaseOrder EmptyOrder()
        {
            MaxTotalCost unlimitedTotalCost = MaxTotalCost.Unlimited();
            return new PurchaseOrder(GenerateId(), unlimitedTotalCost);
        }
    }
}