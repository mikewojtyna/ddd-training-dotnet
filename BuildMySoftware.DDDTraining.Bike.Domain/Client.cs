namespace BuildMySoftware.DDDTraining.Bike
{
    public class Client
    {
        private readonly Money _funds;

        public Client(Money funds)
        {
            _funds = funds;
        }

        public Money Funds()
        {
            return _funds;
        }
    }
}