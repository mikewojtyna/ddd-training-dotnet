namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeRentResult
    {
        public BikeRentResult(BikeRent bikeRent)
        {
            BikeRent = bikeRent;
        }

        public bool IsSuccess { get; }
        public BikeRent BikeRent { get; set; }
    }
}