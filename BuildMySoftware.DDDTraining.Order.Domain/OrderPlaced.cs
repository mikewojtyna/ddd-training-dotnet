namespace BuildMySoftware.DDDTraining.Order
{
    public class OrderPlaced
    {
        public Order Order { get; }

        public OrderPlaced(Order order)
        {
            Order = order;
        }

        public override string ToString()
        {
            return $"{nameof(Order)}: {Order}";
        }

        protected bool Equals(OrderPlaced other)
        {
            return Equals(Order, other.Order);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderPlaced) obj);
        }

        public override int GetHashCode()
        {
            return (Order != null ? Order.GetHashCode() : 0);
        }
    }
}