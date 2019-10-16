using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Bike.Tests
{
    public class BikeRentTest
    {
        [Test]
        public void Given_RackWithSingleBike_When_RentABike_ThenBikeIsRent()
        {
            // given
            Bike bike = NonBrokenBike();
            BikeRack rack = BikeTestsObjectMother.BikeRackWithSingleBike(bike);
            Client client = ClientWithSufficientFunds();


            // when
            BikeRentResult result = rack.RentBikeBy(client, bike.Id);

            // then
            Check.That(result.BikeRent).IsNotNull();
        }

        private Client ClientWithSufficientFunds()
        {
            return ClientWith(PlnOf(10.00m));
        }

        [Test]
        public void Given_EmptyBikeRack_When_RentABike_ThenRentFails()
        {
            // given
            BikeRack bikeRack = EmptyBikeRack();
            Client client = ClientWithSufficientFunds();
            Bike bike = NonBrokenBike();
            // when
            BikeRentResult result = bikeRack.RentBikeBy(client, bike.Id);

            // then
            Check.That(result.BikeRent).IsNull();
        }

        [Test]
        public void Given_RackWithAtLeastOneBike_When_RentABikeByClientWithAtLeast10Pln_ThenBikeIsRent()
        {
            // given
            Bike bike = NonBrokenBike();
            BikeRack bikeRack = BikeTestsObjectMother.BikeRackWithSingleBike(bike);
            Client client = ClientWith(PlnOf(10.00m));


            // when
            var bikeRentResult = bikeRack.RentBikeBy(client, bike.Id);

            // then
            Check.That(bikeRentResult.BikeRent).IsNotNull();
        }

        [Test]
        public void Given_RackWithAtLeastOneBike_When_RentABikeByClientWithLessThan10Pln_ThenBikeRentFails()
        {
            // given
            BikeRack bikeRack = BikeRackWithAtLeastSingleBike();
            Client client = ClientWith(PlnOf(9.00m));
            Bike bike = NonBrokenBike();

            // when
            var result = bikeRack.RentBikeBy(client, bike.Id);

            // then
            Check.That(result.BikeRent).IsNull();
        }

        private Bike NonBrokenBike()
        {
            return new Bike();
        }

        [Test]
        public void Given_RackWithAtLeastOneBike_When_RentedBikeIsBroken_ThenBikeRentFails()
        {
            // given
            Bike brokenBike = BrokenBike();
            BikeRack bikeRack = BikeWithBrokenSingleBike(brokenBike);
            Client client = ClientWithSufficientFunds();

            // when
            var result = bikeRack.RentBikeBy(client, brokenBike.Id);
            // then
            Check.That(result.BikeRent).IsNull();
            Check.That(result.BikeBroken).IsNotNull();

        }

        [Test]
        public void Given_InvalidBikeId_ThenBikeRentFails()
        {
            // given
            var invalidId = AnyBikeId();
            Bike bike = NonBrokenBike();
            Client client = ClientWithSufficientFunds();
            BikeRack bikeRack = BikeTestsObjectMother.BikeRackWithSingleBike(bike);

            // when
            var result = bikeRack.RentBikeBy(client, invalidId);

            // then
            Check.That(result.TriedToRentInvalidBike).IsNotNull();
        }

        [Test]
        public void Given_RackWithOneBike_When_TryToRentBikeTwice_Then_SecondRentFails()
        {
            // given
            Bike bike = NonBrokenBike();
            Client client = ClientWithSufficientFunds();
            BikeRack bikeRack = BikeTestsObjectMother.BikeRackWithSingleBike(bike);

            // when
            bikeRack.RentBikeBy(client, bike.Id);
            var result = bikeRack.RentBikeBy(client, bike.Id);

            // then
            Check.That(result.BikeRent).IsNull();
            Check.That(result.TriedToRentInvalidBike).IsNotNull();
        }

        [Test]
        public void Given_ClientWithRentedTwoBikes_TryToRentAnotherBike_Then_RentFails()
        {
            // given
            Bike bike = NonBrokenBike();
            Client client = ClientWithActivesTwoBikes(PlnOf(10.00m));
            BikeRack bikeRack = BikeTestsObjectMother.BikeRackWithSingleBike(bike);

            // when
            var result = bikeRack.RentBikeBy(client, bike.Id);

            // then
            Check.That(result.BikeRent).IsNull();
            Check.That(result.RentLimitExceeded).IsNotNull();
        }

        private Client ClientWithActivesTwoBikes(Money money)
        {
            int activesBikes = 2;
            return new Client(money, activesBikes);
        }

        private BikeId AnyBikeId()
        {
            return new BikeId();
        }
        private Bike BrokenBike()
        {
            return new Bike()
            {
                IsBroken = true
            };
        }

        private BikeRack BikeWithBrokenSingleBike(Bike bike)
        {
            return BikeRack.WithBikes(bike);

        }

        private Client ClientWith(Money money)
        {
            return new Client(money, 0);
        }

        private Money PlnOf(decimal d)
        {
            return new Money(d, "PLN");
        }

        private BikeRack BikeRackWithAtLeastSingleBike()
        {
            return BikeRack.WithAvailableBikes(1);
        }

        private BikeRack EmptyBikeRack()
        {
            return BikeRack.EmptyRack();
        }
    }
}