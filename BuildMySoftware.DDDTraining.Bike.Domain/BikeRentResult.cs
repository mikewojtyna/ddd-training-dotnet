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
        public bool IsSuccess { get; }
        public BikeRent BikeRent { get; set; }
        public BikeBroken BikeBroken { get; set; }
        public TriedToRentInvalidBike TriedToRentInvalidBike { get; set; }
    }
}