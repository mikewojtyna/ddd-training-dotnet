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
            Bike bike = new Bike();
            
            // when
            BikeRent bikeRent = bike.Rent();

            // then
            Check.That(bikeRent).IsNotNull();
        }
    }
}