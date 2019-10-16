using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    class Order
    {

        private List<OrderItem> Items { get; set; } = new List<OrderItem>();
        private Money TotalOrderValue { get; set; } = Money.Zero();

        internal Money CalculateTotalCost()
        {
            return TotalOrderValue;
        }

        public static Order WithProducts(params Product[] products)
        {
            var order = new Order();
            //order.Products.AddRange(products);
            foreach (var p in products)
                order.AddNewProduct(p);
            return order;
        }

        internal void AddNewProduct(Product newProduct)
        {
            var item = Items.FirstOrDefault(x => x.Equals(newProduct));
            if (item == null) Items.Add(new OrderItem(1, newProduct));
            else item.IncreaseQuantity();
            TotalOrderValue = Recalculate();
        }

        private Money Recalculate()
        {
            return Items.Select(x => x.Cost()).Aggregate((x, y) => x.Add(y));
        }
    }
}
