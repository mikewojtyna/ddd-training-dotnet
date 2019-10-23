using BuildMySoftware.DDDTraining.Bike.Domain.Tests;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Bike.Tests
{
    public class BikeReturnTests
    {
        [Test]
        public void CanReturnABike()
        {
            // given
            BikeRack bikeRack = BikeRentTestFixtureUtils.EmptyBikeRack();
            RentBike rentBike = AnyBike();

            // when
            BikeReturned bikeReturned = bikeRack.ReturnToRack(rentBike);

            // then
            Check.That(bikeReturned).IsNotNull();
        }

        [Test]
        public void Given_EmptyRackWithCapacityOfJustOneBike_When_ReturnToRackTwoBikes_ThenSecondReturnFails()
        {
            // given
            BikeRack bikeRack = EmptyRackWithCapacityForSingleBike();
            RentBike firstRentBike = AnyBike();
            RentBike secondRentBike = AnyBike();

            // when
            var returnEvent = bikeRack.ReturnToRack(firstRentBike);
            Check.ThatCode(() => bikeRack.ReturnToRack(secondRentBike))
                
                // then
                .Throws<FailedToReturnBike>();
            Check.That(returnEvent).IsNotNull();
        }

        private BikeRack EmptyRackWithCapacityForSingleBike()
        {
            return BikeRack.EmptyWithCapacity(1);
        }

        private RentBike AnyBike()
        {
            return new RentBike();
        }

        private BikeUser AnyBikeUser()
        {
            return BikeRentTestFixtureUtils.AnyBikeUser();
        }
    }
}