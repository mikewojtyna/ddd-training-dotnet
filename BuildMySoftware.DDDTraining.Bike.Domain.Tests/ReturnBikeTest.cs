using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Bike.Domain.Tests
{
    public class ReturnBikeTest
    {
        [Test]
        public void CanReturnABike()
        {
            // given
            BikeRack bikeRack = BikeTestsObjectMother.AnyBikeRack();

            // when
            BikeReturned bikeReturned = bikeRack.ReturnBike();

            // then
            Check.That(bikeReturned).IsNotNull();
        }
    }
}