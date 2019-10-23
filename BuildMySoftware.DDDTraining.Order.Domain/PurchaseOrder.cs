using System.Collections.Generic;
using System.Linq;
using BuildMySoftware.DDDTraining.Order.Tests;

namespace BuildMySoftware.DDDTraining.Order
{
    public class PurchaseOrder
    {
        private List<Product> products = new List<Product>();
        private MaxTotalCost MaxTotalCost { get; set; }

        public PurchaseOrder(MaxTotalCost maxTotalCost)
        {
            MaxTotalCost = maxTotalCost;
        }

        public Money TotalCost()
        {
            return products
                .Select(p => p.Cost())
                .DefaultIfEmpty(Money.Zero())
                .Aggregate((accumulated, current) => accumulated.Add(current));
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            if (MaxTotalCost.IsExceededBy(TotalCost()))
            {
                throw new MaxTotalCostExceeded();
            }
        }
    }
}