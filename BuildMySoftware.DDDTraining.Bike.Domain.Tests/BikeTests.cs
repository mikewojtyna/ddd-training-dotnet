using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Bike.Domain.Tests
{
    public class BikeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_BikeRackWithSingleBike_ThenCanRentABike()
        {
            // given
            BikeRack bikeRack = BikeRackWithSingleBike();

            // when
            BikeRent bikeRent = bikeRack.Rent();

            // then
            Check.That(bikeRent).IsNotNull();
        }

        [Test]
        public void Given_EmptyBikeRack_When_RentABike_ThenRentFails()
        {
            // given
            BikeRack bikeRack = EmptyBikeRack();

            // when
            Check.ThatCode(() => bikeRack.Rent())

                // then
                .Throws<FailedToRentABike>();
        }

        [Test]
        public void Given_BikeRackWithSingleBike_When_RentABikeTwice_ThenOnlySecondRentFails()
        {
            // given
            BikeRack bikeRack = BikeRackWithSingleBike();

            // when
            var bikeRent = bikeRack.Rent();
            Check.ThatCode(() => bikeRack.Rent())

                // then
                .Throws<FailedToRentABike>();
            Check.That(bikeRent).IsNotNull();
        }

        private BikeRack EmptyBikeRack()
        {
            return BikeRack.Empty();
        }

        private BikeRack BikeRackWithSingleBike()
        {
            return BikeRack.WithSingleBike();
        }
    }
}