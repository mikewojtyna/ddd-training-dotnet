using System;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    internal class OrderLimit
    {
        private Money Limit { get; set; }
        private bool IsLimited { get; set; }
        
        public static OrderLimit LimitedBy(Money money)
        {
            return new OrderLimit() { Limit = money, IsLimited = true };            
        }

        public bool IsExceededBy(Money cost)
        {
            return IsLimited && cost.IsGreaterThan(Limit);
        }

        static internal OrderLimit Unlimited()
        {
            return new OrderLimit();            
        }
    }
}