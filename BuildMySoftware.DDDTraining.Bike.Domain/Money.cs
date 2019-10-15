namespace BuildMySoftware.DDDTraining.Bike
{
    public class Money
    {
        public Money(in decimal amount, string pln)
        {
            Amount = amount;
            Currency = pln;
        }

        public string Currency { get; }

        public decimal Amount { get; }

        public bool IsGreaterThanOrEqual(decimal amount)
        {
            return Amount >= amount;
        }
    }
}