using System;

namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeRentFailedException : Exception
    {
        public BikeRentFailedException(string bikeRentFailed) : base(bikeRentFailed)
        {
        }
    }
}