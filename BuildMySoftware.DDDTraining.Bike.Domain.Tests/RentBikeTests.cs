using BuildMySoftware.DDDTraining.Bike.Domain.Tests;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Bike.Tests
{
    public class RentBikeTests
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
            BikeRent bikeRent = bikeRack.RentBy(AnyBikeUser());

            // then
            Check.That(bikeRent).IsNotNull();
        }

        [Test]
        public void Given_EmptyBikeRack_When_RentABike_ThenRentFails()
        {
            // given
            BikeRack bikeRack = EmptyBikeRack();

            // when
            Check.ThatCode(() => bikeRack.RentBy(AnyBikeUser()))

                // then
                .Throws<FailedToRentABike>();
        }

        [Test]
        public void Given_BikeRackWithSingleBike_When_RentABikeTwice_ThenOnlySecondRentFails()
        {
            // given
            BikeRack bikeRack = BikeRackWithSingleBike();

            // when
            var bikeRent = bikeRack.RentBy(AnyBikeUser());
            Check.ThatCode(() => bikeRack.RentBy(AnyBikeUser()))

                // then
                .Throws<FailedToRentABike>();
            Check.That(bikeRent).IsNotNull();
        }

        [Test]
        public void BikeUserCanRentABike()
        {
            // given
            BikeRack bikeRack = BikeRackWithSingleBike();
            BikeUser bikeUser = AnyBikeUser();

            // when
            var bikeRent = bikeRack.RentBy(bikeUser);

            // then
            Check.That(bikeRent).IsNotNull();
        }

        [Test]
        public void Given_BlockedBikeUser_When_RentABikeByThisUser_Then_RentFails()
        {
            // given
            BikeRack bikeRack = BikeRackWithSingleBike();
            BikeUser blockedUser = BlockedUser();

            // when
            Check.ThatCode(() => bikeRack.RentBy(blockedUser))
                
                // then
                .Throws<FailedToRentABike>();
        }

        private BikeUser BlockedUser()
        {
            return BikeUser.Blocked();
        }

        private BikeUser AnyBikeUser()
        {
            return BikeRentTestFixtureUtils.AnyBikeUser();
        }

        private BikeRack EmptyBikeRack()
        {
            return BikeRentTestFixtureUtils.EmptyBikeRack();
        }

        private BikeRack BikeRackWithSingleBike()
        {
            return BikeRack.WithSingleBike();
        }
    }
}