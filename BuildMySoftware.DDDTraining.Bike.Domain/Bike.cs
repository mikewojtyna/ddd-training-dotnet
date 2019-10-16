using System;
using System.Collections.Generic;
using System.Text;

namespace BuildMySoftware.DDDTraining.Bike
{
    public class Bike
    {
        public BikeId Id { get; private set; }
        public bool IsBroken { get; set; }
        public Bike(BikeId id)
        {
            Id = id;
        }
        public Bike()
        {
            Id = new BikeId(Guid.NewGuid());
        }
    }
}
