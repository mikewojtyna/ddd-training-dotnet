using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    public class Product
    {
        public Product(Money price, ProductId productId)
        {
            Price = price;
            ProductId = productId;
        }

        public Money Price { get; }
        public ProductId ProductId { get; }

        protected bool Equals(Product other)
        {
            return Equals(ProductId, other.ProductId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return (ProductId != null ? ProductId.GetHashCode() : 0);
        }
    }
}