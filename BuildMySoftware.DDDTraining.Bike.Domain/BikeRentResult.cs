namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeRentResult
    {
        public BikeRentResult(TriedToRentInvalidBike triedToRentInvalidBike)
        {
            TriedToRentInvalidBike = triedToRentInvalidBike;
        }
        public BikeRentResult(BikeRent bikeRent)
        {
            BikeRent = bikeRent;
        }
        public BikeRentResult(BikeBroken bikeBroken)
        {
            BikeBroken = bikeBroken;
        }
        public BikeRentResult(RentLimitExceeded rentLimitExceeded)
        {
            RentLimitExceeded = rentLimitExceeded;
        }
        public BikeRent BikeRent { get; private set; }
        public BikeBroken BikeBroken { get; private set; }
        public TriedToRentInvalidBike TriedToRentInvalidBike { get; private set; }
        public RentLimitExceeded RentLimitExceeded { get; private set; }
    }
}