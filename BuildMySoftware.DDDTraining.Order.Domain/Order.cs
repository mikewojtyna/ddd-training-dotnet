using System.Collections.Generic;
using System.Linq;
using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    public class Order
    {
        private IList<OrderItem> Items { get; }
        public Money TotalCost { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public void AddProduct(Product product)
        {
            var matchingItem = Items.FirstOrDefault(p => p.Equals(product));
            if (matchingItem == null)
                Items.Add(new OrderItem(product, 1));
            else
            {
                matchingItem.IncreaseQuantity();
            }

            TotalCost = Items.Select(item => item.Cost())
                .Aggregate((partialCost, currentCost) => partialCost.Add(currentCost.Amount));
        }
    }
}