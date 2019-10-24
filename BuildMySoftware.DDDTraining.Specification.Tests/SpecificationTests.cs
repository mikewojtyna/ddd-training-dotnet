using System;
using BuildMySoftware.DDDTraining.Order;
using BuildMySoftware.DDDTraining.Order.Tests;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Specification.Tests
{
    public class SpecificationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MaxTotalCostSuccessSpecificationExample()
        {
            // given
            Money maxTotalCost = Money.Of(100.00m, "USD");
            ISpecification<PurchaseOrder> specification = new MaxTotalCostPurchaseOrderSpecification(maxTotalCost);
            PurchaseOrder purchaseOrder =
                new PurchaseOrder(new PurchaseOrderId(Guid.NewGuid()), MaxTotalCost.Unlimited());

            // when
            var isOrderApplicable = specification.applies(purchaseOrder);

            // then
            Check.That(isOrderApplicable).IsTrue();
        }

        [Test]
        public void MaxTotalCostFailSpecificationExample()
        {
            // given
            Money maxTotalCost = Money.Of(100.00m, "USD");
            ISpecification<PurchaseOrder> specification = new MaxTotalCostPurchaseOrderSpecification(maxTotalCost);
            PurchaseOrder purchaseOrder =
                new PurchaseOrder(new PurchaseOrderId(Guid.NewGuid()), MaxTotalCost.Unlimited());
            purchaseOrder.AddProduct(new Product(Money.Of(200.00m, "US"), "Product name"));

            // when
            var isOrderApplicable = specification.applies(purchaseOrder);

            // then
            Check.That(isOrderApplicable).IsFalse();
        }

        [Test]
        public void AndSpecificationExample()
        {
            // given
            Money maxTotalCost = Money.Of(100.00m, "USD");
            ISpecification<PurchaseOrder> specification =
                new MaxTotalCostPurchaseOrderSpecification(maxTotalCost).And(
                    new NeverApplicableSpecification<PurchaseOrder>());
            PurchaseOrder purchaseOrder =
                new PurchaseOrder(new PurchaseOrderId(Guid.NewGuid()), MaxTotalCost.Unlimited());

            // when
            var isOrderApplicable = specification.applies(purchaseOrder);

            // then
            Check.That(isOrderApplicable).IsFalse();
        }
    }
}