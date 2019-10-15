namespace BuildMySoftware.DDDTraining.SharedKernel
{
    public class Money
    {
        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected bool Equals(Money other)
        {
            return Currency == other.Currency && Amount == other.Amount;
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
                return ((Currency != null ? Currency.GetHashCode() : 0) * 397) ^ Amount.GetHashCode();
            }
        }

        public string Currency { get; }

        public decimal Amount { get; }

        public bool IsGreaterThanOrEqual(decimal amount)
        {
            return Amount >= amount;
        }

        public Money Add(decimal amount)
        {
            return new Money(Amount + amount, Currency);
        }

        public Money Multiply(decimal amount)
        {
            return new Money(Amount * amount, Currency);
        }
    }
}