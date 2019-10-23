using BuildMySoftware.DDDTraining.Bike.Domain.Tests;

namespace BuildMySoftware.DDDTraining.Bike.Tests
{
    public class BikeRentTestFixtureUtils
    {
        public static BikeRack EmptyBikeRack()
        {
            return BikeRack.Empty();
        }

        public static BikeUser AnyBikeUser()
        {
            return new BikeUser();
        }
    }
}