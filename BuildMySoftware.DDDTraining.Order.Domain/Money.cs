namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Unit { get; private set; }

        public override string ToString()
        {
            return $"{nameof(Amount)}: {Amount}, {nameof(Unit)}: {Unit}";
        }

        public Money Add(Money money)
        {
            return new Money {Amount = Amount + money.Amount, Unit = Unit};
        }

        public static Money Zero()
        {
            return new Money {Amount = 0.00m, Unit = "USD"};
        }

        protected bool Equals(Money other)
        {
            return Amount == other.Amount && Unit == other.Unit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
            }
        }

        public static Money Of(in decimal amount, string usd)
        {
            return new Money {Amount = amount, Unit = usd};
        }

        public bool IsGreaterThan(Money limit)
        {
            return Amount > limit.Amount;
        }
    }
}