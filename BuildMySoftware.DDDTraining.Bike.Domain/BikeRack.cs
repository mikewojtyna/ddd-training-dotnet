using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeRack
    {
        private List<Bike> AvailableBikes { get; set; } = new List<Bike>();

        public BikeRentResult RentBikeBy(Client client, BikeId bikeId)
        {
            var matchingBike = AvailableBikes.FirstOrDefault(x => x.Id.Equals(bikeId));
            if (matchingBike == null)
            {
                return new BikeRentResult(new TriedToRentInvalidBike());
            }
            if (AvailableBikes.Count == 0)
                return new BikeRentResult((BikeRent)null);

            if (matchingBike.IsBroken)
            {
                return new BikeRentResult(new BikeBroken());
            }
            if (client.ActivesBikes >= 2)
            {
                return new BikeRentResult(new RentLimitExceeded());
            }
            if (client.Funds().IsGreaterThanOrEqual(10.00m))
            {
                AvailableBikes.Remove(matchingBike);
                return new BikeRentResult(new BikeRent());
            }





            return new BikeRentResult((BikeRent)null);
        }

        public BikeReturned ReturnBike()
        {
            return new BikeReturned();
        }

        public static BikeRack EmptyRack()
        {
            return new BikeRack();
        }

        public static BikeRack WithSingleBike()
        {
            return new BikeRack
            {
                AvailableBikes = new List<Bike>()
                {
                    DefaultBike()
                }
            };
        }
        public static BikeRack WithSingleBike(Bike bike)
        {
            return new BikeRack
            {
                AvailableBikes = new List<Bike>()
                {
                    bike
                }
            };
        }
        private static Bike DefaultBike()
        {
            return new Bike(new BikeId(Guid.NewGuid()));
        }

        public static BikeRack WithAvailableBikes(int availableBikes)
        {
            BikeRack bikeRack = new BikeRack();

            for (int i = 0; i < availableBikes; i++)
            {
                bikeRack.AvailableBikes.Add(DefaultBike());
            }
            return bikeRack;
        }


        public static BikeRack WithBikes(params Bike[] bikes)
        {
            BikeRack bikeRack = new BikeRack();
            bikeRack.AvailableBikes.AddRange(bikes);
            return bikeRack;
        }
    }
}