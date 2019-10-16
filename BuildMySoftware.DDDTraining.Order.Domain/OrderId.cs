using System;

namespace BuildMySoftware.DDDTraining.Order
{
    public class OrderId
    {
        private Guid Id { get; set; }

        public OrderId(Guid id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}";
        }

        protected bool Equals(OrderId other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderId) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}