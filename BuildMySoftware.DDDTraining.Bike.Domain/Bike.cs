using System;
using BuildMySoftware.DDDTraining.Bike.Domain.Tests;

namespace BuildMySoftware.DDDTraining.Bike
{
    public class Bike
    {
        public BikeRent Rent()
        {
            return new BikeRent();
        }
    }
}