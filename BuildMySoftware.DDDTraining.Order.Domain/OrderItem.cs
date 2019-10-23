using BuildMySoftware.DDDTraining.Order.Tests;

namespace BuildMySoftware.DDDTraining.Order
{
    internal class OrderItem
    {
        internal int Quantity { get; set; }
        private Product Product { get; }

        internal OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }

        internal bool HasProduct(Product product)
        {
            return Product.Name.Equals(product.Name);
        }

        internal Money Cost()
        {
            return Product.Price.MultiplyBy(Quantity);
        }

        public override string ToString()
        {
            return $"{nameof(Quantity)}: {Quantity}, {nameof(Product)}: {Product}";
        }

        protected bool Equals(OrderItem other)
        {
            return Quantity == other.Quantity && Equals(Product, other.Product);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Quantity * 397) ^ (Product != null ? Product.GetHashCode() : 0);
            }
        }
    }
}