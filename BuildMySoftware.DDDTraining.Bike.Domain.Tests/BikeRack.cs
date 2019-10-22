namespace BuildMySoftware.DDDTraining.Bike.Domain.Tests
{
    public class BikeRack
    {
        private int AvailableBikes;

        private BikeRack()
        {
            AvailableBikes = 0;
        }

        public BikeRent Rent()
        {
            if (IsEmpty())
                throw new FailedToRentABike();
            AvailableBikes--;
            return new BikeRent();
        }

        public static BikeRack Empty()
        {
            return new BikeRack();
        }

        public static BikeRack WithSingleBike()
        {
            return new BikeRack {AvailableBikes = 1};
        }

        private bool IsEmpty()
        {
            return AvailableBikes == 0;
        }
    }
}