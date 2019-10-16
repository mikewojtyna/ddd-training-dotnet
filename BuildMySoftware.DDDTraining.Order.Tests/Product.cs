using System;
using System.Collections.Generic;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    internal class Product
    {
        public ProductId Id { get; set; }
        public Money UnitPrice { get; private set; }

        public Product(Money unitPrice)
        {
            UnitPrice = unitPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   EqualityComparer<ProductId>.Default.Equals(Id, product.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}