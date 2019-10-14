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
        public void CanRentABike()
        {
            // given
            var bikeRack = nonEmptyBikeRack();
            var bikeId = new BikeId();
            Client client = clientWithSomeFunds();

            // when
            var bikeRent = bikeRack.Rent(bikeId, client);

            // then
            Check.That(bikeRent).IsNotNull();
        }

        [Test]
        public void Given_BikeRackWithoutASingleBike_When_RentABike_ThenRentFails()
        {
            // given
            var bikeRack = emptyBikeRack();
            BikeId bikeId = anyBikeId();
            Client client = clientWithSomeFunds();

            // when
            Check.ThatCode(() => bikeRack.Rent(bikeId, client))

                // then
                .Throws<BikeRentFailedException>();
        }

        [Test]
        public void Given_BikeRackWithSingleBike_When_RentABikeTwice_Then_SecondRentFails()
        {
            // given
            var bikeRack = bikeRackWithSingleBike();
            BikeId bikeId = anyBikeId();
            Client client = clientWithSomeFunds();

            // when
            bikeRack.Rent(bikeId, client);
            Check.ThatCode(() => bikeRack.Rent(bikeId, client))

                // then
                .Throws<BikeRentFailedException>();
        }

        [Test]
        public void When_RentBikeByClientWithoutFunds_ThenRentFails()
        {
            // given
            BikeRack bikeRack = nonEmptyBikeRack();
            BikeId bikeId = anyBikeId();
            Client client = clientWithoutFunds();

            // when
            Check.ThatCode(() => bikeRack.Rent(bikeId, client))

                // then
                .Throws<BikeRentFailedException>()
                .WithMessage("Client has no funds");
        }

        private Client clientWithSomeFunds()
        {
            return new Client();
        }

        private static BikeRack nonEmptyBikeRack()
        {
            return new BikeRack(1);
        }

        private Client clientWithoutFunds()
        {
            return Client.WithoutFunds();
        }

        private BikeRack bikeRackWithSingleBike()
        {
            return new BikeRack(1);
        }

        private static BikeId anyBikeId()
        {
            return new BikeId();
        }

        private static BikeRack emptyBikeRack()
        {
            return new BikeRack(0);
        }
    }
}