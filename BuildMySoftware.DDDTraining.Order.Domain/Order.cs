using System.Collections.Generic;
using System.Linq;

namespace BuildMySoftware.DDDTraining.Order
{
    public class Order
    {

        private List<OrderItem> Items { get; set; } = new List<OrderItem>();
        private Money TotalOrderValue { get; set; } = Money.Zero();

        private OrderLimit OrderLimit { get; set; }

        public Money CalculateTotalCost()
        {
            return TotalOrderValue;
        }

        public Order()
        {
            OrderLimit = OrderLimit.Unlimited();
        }

        public static Order WithProducts(params Product[] products)
        {
            var order = new Order();
            //order.Products.AddRange(products);
            foreach (var p in products)
                order.AddNewProduct(p);
            return order;
        }

        public Order(OrderLimit limit)
        {
            OrderLimit = limit;
        }

        public void AddNewProduct(Product newProduct)
        {
            var item = Items.FirstOrDefault(x => x.Equals(newProduct));
            if (item == null) Items.Add(new OrderItem(1, newProduct));
            else item.IncreaseQuantity();
            TotalOrderValue = Recalculate();
        }

        private Money Recalculate()
        {
            var totalCost =  Items.Select(x => x.Cost()).Aggregate((x, y) => x.Add(y));
            if (OrderLimit.IsExceededBy(totalCost)) throw new OrderMaxTotalCostExceeded();
            return totalCost;
        }
    }
}
