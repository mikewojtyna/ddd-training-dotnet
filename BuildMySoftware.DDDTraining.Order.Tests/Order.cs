using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    class Order
    {

        private List<Product> Products { get; set; } = new List<Product>();

        internal Money CalculateTotalCost()
        {
            return Money.Of(Products.Sum(x => x.UnitPrice.Amount), CurrencyUnit.USD);
        }

        public static Order WithProducts(params Product[] products)
        {
            var order = new Order();
            order.Products.AddRange(products);
            return order;
        }
    }
}
