using BuildMySoftware.DDDTraining.SharedKernel;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Bike.Domain.Tests
{
    public class BikeRentTest
    {
        [Test]
        public void Given_RackWithSingleBike_When_RentABike_ThenBikeIsRent()
        {
            // given
            BikeRack rack = BikeTestsObjectMother.BikeRackWithSingleBike();
            Client client = ClientWithSufficientFunds();

            // when
            BikeRentResult result = rack.RentBikeBy(client);

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

            // when
            BikeRentResult result = bikeRack.RentBikeBy(client);

            // then
            Check.That(result.BikeRent).IsNull();
        }

        [Test]
        public void Given_RackWithAtLeastOneBike_When_RentABikeByClientWithAtLeast10Pln_ThenBikeIsRent()
        {
            // given
            BikeRack bikeRack = BikeRackWithAtLeastSingleBike();
            Client client = ClientWith(PlnOf(10.00m));

            // when
            var bikeRentResult = bikeRack.RentBikeBy(client);

            // then
            Check.That(bikeRentResult.BikeRent).IsNotNull();
        }

        [Test]
        public void Given_RackWithAtLeastOneBike_When_RentABikeByClientWithLessThan10Pln_ThenBikeRentFails()
        {
            // given
            BikeRack bikeRack = BikeRackWithAtLeastSingleBike();
            Client client = ClientWith(PlnOf(9.00m));

            // when
            var result = bikeRack.RentBikeBy(client);

            // then
            Check.That(result.BikeRent).IsNull();
        }

        private Client ClientWith(Money money)
        {
            return new Client(money);
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