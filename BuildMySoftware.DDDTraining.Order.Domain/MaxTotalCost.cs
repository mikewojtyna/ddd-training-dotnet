namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class MaxTotalCost
    {
        private Money Limit { get; set; }
        private bool IsLimited { get; set; }

        internal bool IsExceededBy(Money amount)
        {
            if (IsLimited)
                return amount.IsGreaterThan(Limit);
            return false;
        }

        private MaxTotalCost()
        {
        }

        public MaxTotalCost(Money amount)
        {
            IsLimited = true;
            Limit = amount;
        }

        public static MaxTotalCost Unlimited()
        {
            return new MaxTotalCost();
        }
    }
}