using System.Collections.Generic;

namespace BuildMySoftware.DDDTraining.Bike
{
    public class Client
    {
        private readonly Money _funds;
        public readonly int ActivesBikes;

        public Client(Money funds, int activesBikes)
        {
            _funds = funds;
            ActivesBikes = activesBikes;
        }

        public Money Funds()
        {
            return _funds;
        }
    }
}