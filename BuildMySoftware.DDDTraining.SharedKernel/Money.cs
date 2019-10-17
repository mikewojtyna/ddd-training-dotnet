﻿using System;

namespace BuildMySoftware.DDDTraining.SharedKernel
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public CurrencyUnit Unit { get; private set; }

        public bool IsZero()
        {
            return Amount == 0;
        }

        public override string ToString()
        {
            return $"{Unit.ToString()} {Amount}";
        }

        public Money MultiplyBy(int quantity)
        {
            return Of(Amount * quantity, Unit);
        }

        public static Money Of(decimal amount, CurrencyUnit unit)
        {
            return new Money() {Amount = amount, Unit = unit};
        }

        public static Money Zero()
        {
            return new Money() {Amount = 0m, Unit = CurrencyUnit.ANY};
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

        public Money Add(Money money)
        {
            if (money.IsZero())
                return this;
            CheckIfUnitsMatch(money);
            return Of(money.Amount + Amount, Unit);
        }

        public bool IsGreaterThan(Money money)
        {
            CheckIfUnitsMatch(money);
            return this.Amount > money.Amount;
        }

        private void CheckIfUnitsMatch(Money money)
        {
            if (money.Unit != this.Unit) throw new InvalidOperationException("Not the same currency.");
        }

        public bool IsGreaterThanOrEqual(decimal amount)
        {
            return this.Amount >= amount;
        }

        public Money MultiplyBy(double quantity)
        {
            return Of(Amount * (decimal) quantity, Unit);
        }
    }

    public enum CurrencyUnit
    {
        USD,
        ANY,
        PLN
    }
}