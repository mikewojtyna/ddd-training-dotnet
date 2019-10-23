using System;

namespace BuildMySoftware.DDDTraining.Order
{
    public class PurchaseOrderId
    {
        private Guid Value { get; }

        public PurchaseOrderId(Guid value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }

        protected bool Equals(PurchaseOrderId other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PurchaseOrderId) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}