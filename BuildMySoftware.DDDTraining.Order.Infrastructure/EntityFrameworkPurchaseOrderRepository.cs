using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BuildMySoftware.DDDTraining.Order.Tests;

namespace BuildMySoftware.DDDTraining.Order
{
    public class EntityFrameworkPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly PurchaseOrderContext _dbContext;

        public EntityFrameworkPurchaseOrderRepository(PurchaseOrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PurchaseOrder Load(PurchaseOrderId id)
        {
            return Rehydrate(_dbContext.PurchaseOrders.FirstOrDefault(o =>
                o.Id.Equals(GetFieldOrPropertyValue<Guid>(id, "Value"))));
        }

        public void Save(PurchaseOrder order)
        {
            _dbContext.PurchaseOrders.Add(Flatten(order));
            _dbContext.SaveChanges();
        }

        private PurchaseOrderDb Flatten(PurchaseOrder order)
        {
            List<OrderItem> items = GetFieldOrPropertyValue<List<OrderItem>>(order, "_items");
            List<OrderItemDb> itemsDb = items.Select(item =>
                {
                    Product product = GetFieldOrPropertyValue<Product>(item, "Product");
                    return new OrderItemDb()
                    {
                        Product = product.Name,
                        Quantity = GetFieldOrPropertyValue<int>(item, "Quantity"),
                        ProductPrice = product.Price.Amount, ProductPriceCurrency = product.Price.Unit
                    };
                })
                .ToList();
            MaxTotalCost maxTotalCost = GetFieldOrPropertyValue<MaxTotalCost>(order, "MaxTotalCost");
            Money maxTotalCostLimit = GetFieldOrPropertyValue<Money>(maxTotalCost, "Limit");
            var purchaseOrderDb = new PurchaseOrderDb
            {
                Id = GetFieldOrPropertyValue<Guid>(order.Id, "Value"),
                MaxQuantityPerProduct = GetFieldOrPropertyValue<int>(order, "MaxQuantityPerProduct"), Items = itemsDb,
                MaxTotalCostAmount = maxTotalCostLimit?.Amount ?? 0m,
                MaxTotalCostCurrency = maxTotalCostLimit?.Unit,
                MaxTotalCostLimited = GetFieldOrPropertyValue<bool>(maxTotalCost, "IsLimited")
            };
            return purchaseOrderDb;
        }

        private T GetFieldOrPropertyValue<T>(object obj, string name)
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var objType = obj.GetType();
            var property = objType.GetProperty(name, bindingFlags);
            if (property == null)
                return (T) objType.GetField(name, bindingFlags)?.GetValue(obj);
            return (T) property.GetValue(obj);
        }

        private PurchaseOrder Rehydrate(PurchaseOrderDb purchaseOrderDb)
        {
            if (purchaseOrderDb == null)
                return null;
            MaxTotalCost maxTotalCost;
            if (purchaseOrderDb.MaxTotalCostLimited)
                maxTotalCost = new MaxTotalCost(Money.Of(purchaseOrderDb.MaxTotalCostAmount,
                    purchaseOrderDb.MaxTotalCostCurrency));
            else
            {
                maxTotalCost = MaxTotalCost.Unlimited();
            }

            List<OrderItem> items = purchaseOrderDb.Items.Select(itemDb => new OrderItem(itemDb.Quantity,
                new Product(Money.Of(itemDb.ProductPrice, itemDb.ProductPriceCurrency), itemDb.Product))).ToList();
            return new PurchaseOrder(new PurchaseOrderId(purchaseOrderDb.Id), maxTotalCost,
                purchaseOrderDb.MaxQuantityPerProduct, items);
        }
    }
}