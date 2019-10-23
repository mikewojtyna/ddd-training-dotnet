using System.Collections.Generic;
using System.Linq;
using BuildMySoftware.DDDTraining.Order.Tests;

namespace BuildMySoftware.DDDTraining.Order
{
    public class PurchaseOrder
    {
        public PurchaseOrderId Id { get; }
        private readonly List<OrderItem> _items = new List<OrderItem>();
        private MaxTotalCost MaxTotalCost { get; }
        private int MaxQuantityPerProduct { get; }
        private readonly int DEFAULT_MAX_QUANTITY_PER_PRODUCT = 3;

        public PurchaseOrder(PurchaseOrderId Id, MaxTotalCost maxTotalCost)
        {
            this.Id = Id;
            MaxQuantityPerProduct = DEFAULT_MAX_QUANTITY_PER_PRODUCT;
            MaxTotalCost = maxTotalCost;
        }

        public PurchaseOrder(PurchaseOrderId Id, MaxTotalCost maxTotalCost, int MaxQuantityPerProduct)
        {
            this.Id = Id;
            this.MaxQuantityPerProduct = MaxQuantityPerProduct;
            MaxTotalCost = maxTotalCost;
        }

        /// <summary>
        /// Used to rehydrate the aggregate. Generally this constructor should not be used by regular clients. This might be replaced by reflection calls.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maxTotalCost"></param>
        /// <param name="maxQuantityPerProduct"></param>
        /// <param name="items"></param>
        public PurchaseOrder(PurchaseOrderId id, MaxTotalCost maxTotalCost, int maxQuantityPerProduct,
            List<OrderItem> items)
        {
            Id = id;
            MaxTotalCost = maxTotalCost;
            MaxQuantityPerProduct = maxQuantityPerProduct;
            _items.AddRange(items);
        }

        public Money TotalCost()
        {
            return _items
                .Select(item => item.Cost())
                .DefaultIfEmpty(Money.Zero())
                .Aggregate((accumulated, current) => accumulated.Add(current));
        }

        public void AddProduct(Product product)
        {
            var matchingOrderItem = _items.FirstOrDefault(item => item.HasProduct(product));
            if (matchingOrderItem != null)
            {
                matchingOrderItem.Quantity++;
                if (matchingOrderItem.Quantity > MaxQuantityPerProduct)
                    throw new MaxProductQuantityExceeded();
            }
            else
                _items.Add(new OrderItem(1, product));

            if (MaxTotalCost.IsExceededBy(TotalCost()))
            {
                throw new MaxTotalCostExceeded();
            }
        }

        protected bool Equals(PurchaseOrder other)
        {
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PurchaseOrder) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}