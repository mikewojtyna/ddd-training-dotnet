namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeRack
    {
        private int AvailableBikes { set; get; }

        public BikeRentResult RentBikeBy(Client client)
        {
            if (AvailableBikes == 0)
                return new BikeRentResult(null);
            if (client.Funds().IsGreaterThanOrEqual(10.00m))
                return new BikeRentResult(new BikeRent());
            return new BikeRentResult(null);
        }

        public BikeReturned ReturnBike()
        {
            return new BikeReturned();
        }

        public static BikeRack EmptyRack()
        {
            return new BikeRack {AvailableBikes = 0};
        }

        public static BikeRack WithSingleBike()
        {
            return new BikeRack {AvailableBikes = 1};
        }

        public static BikeRack WithAvailableBikes(int availableBikes)
        {
            return new BikeRack {AvailableBikes = availableBikes};
        }
    }
}