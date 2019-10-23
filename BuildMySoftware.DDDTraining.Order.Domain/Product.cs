namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class Product
    {
        internal string Name { get; }
        public Money Price { get; }
   
        public Product(Money money, string name)
        {
            Price = money;
            Name = name;
        }

        protected bool Equals(Product other)
        {
            return Name == other.Name && Equals(Price, other.Price);
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
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Price != null ? Price.GetHashCode() : 0);
            }
        }
    }
}