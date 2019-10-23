using System;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class RepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SaveUsingRepository()
        {
            // given
            using PurchaseOrderContext dbContext = new PurchaseOrderContext();
            IPurchaseOrderRepository repository = new EntityFrameworkPurchaseOrderRepository(dbContext);
            PurchaseOrder order = new PurchaseOrder(new PurchaseOrderId(Guid.NewGuid()), MaxTotalCost.Unlimited());
            order.AddProduct(new Product(Money.Of(10.00m, "USD"), "tea"));
            order.AddProduct(new Product(Money.Of(10.00m, "USD"), "tea"));
            order.AddProduct(new Product(Money.Of(15.00m, "USD"), "coffee"));

            // when
            repository.Save(order);
            var foundPurchaseOrder = repository.Load(order.Id);

            // then
            Check.That(foundPurchaseOrder).IsEqualTo(order);
        }
    }
}