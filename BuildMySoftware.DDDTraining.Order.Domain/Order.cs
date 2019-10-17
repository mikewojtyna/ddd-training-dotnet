using System;
using System.Collections.Generic;
using System.Linq;
using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    public class Order
    {
        private List<OrderItem> Items { get; set; } = new List<OrderItem>();
        private Money TotalOrderValue { get; set; } = Money.Zero();
        private OrderLimit OrderLimit { get; set; }
        public OrderId Id { get; }
        private readonly DiscountPolicy _discountPolicy;

        public static Order WithProducts(params Product[] products)
        {
            var order = new Order();
            //order.Products.AddRange(products);
            foreach (var p in products)
                order.AddNewProduct(p);
            return order;
        }

        public Order()
        {
            _discountPolicy = DefaultPolicy();
            Id = GenerateId();
            OrderLimit = OrderLimit.Unlimited();
        }

        public Order(OrderLimit limit)
        {
            _discountPolicy = DefaultPolicy();
            Id = GenerateId();
            OrderLimit = limit;
        }

        public Money CalculateTotalCost()
        {
            return TotalOrderValue;
        }

        public void AddNewProduct(Product newProduct)
        {
            var item = Items.FirstOrDefault(x => x.Equals(newProduct));
            if (item == null) Items.Add(new OrderItem(1, newProduct));
            else item.IncreaseQuantity();
            TotalOrderValue = Recalculate();
        }

        private DiscountPolicy DefaultPolicy()
        {
            return o => 0;
        }

        private OrderId GenerateId()
        {
            return new OrderId(Guid.NewGuid());
        }

        private Money Recalculate()
        {
            var totalCost = Items.Select(x => x.Cost()).Aggregate((x, y) => x.Add(y));
            var discount = _discountPolicy(this);
            totalCost = totalCost.MultiplyBy(1 - discount);
            if (OrderLimit.IsExceededBy(totalCost)) throw new OrderMaxTotalCostExceeded();
            return totalCost;
        }
    }
}