namespace BuildMySoftware.DDDTraining.Bike
{
    public class Client
    {
        public static Client WithoutFunds()
        {
            return new Client {Funds = 0.00m};
        }

        private decimal Funds { get; set; }

        public bool HasNoFunds()
        {
            return Funds == 0;
        }
    }
}