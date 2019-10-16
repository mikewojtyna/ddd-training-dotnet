using System;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    internal class Money
    {
        public decimal Amount { get; private set; }
        public CurrencyUnit Unit { get; private set; }

        public override string ToString()
        {
            return $"{Unit.ToString()} {Amount}";
        }

        public static Money Of(decimal amount, CurrencyUnit unit)
        {
            return new Money() { Amount = amount, Unit = unit };
        }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Amount == money.Amount &&
                   Unit == money.Unit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Unit);
        }
    }

    enum CurrencyUnit
    {
        USD
    }
}