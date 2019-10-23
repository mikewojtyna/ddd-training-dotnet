namespace BuildMySoftware.DDDTraining.Bike.Domain.Tests
{
    public class BikeRack
    {
        private int _availableBikes;
        private int _maxCapacity;

        private BikeRack()
        {
            _maxCapacity = 1;
            _availableBikes = 0;
        }

        public BikeRent RentBy(BikeUser bikeUser)
        {
            if(bikeUser.IsBLocked || IsEmpty())
                throw new FailedToRentABike();
            _availableBikes--;
            return new BikeRent();
        }

        public BikeReturned ReturnToRack(RentBike rentBike)
        {
            if(_availableBikes == _maxCapacity)
                throw new FailedToReturnBike();
            _availableBikes++;
            return new BikeReturned();
        }

        public static BikeRack Empty()
        {
            return new BikeRack();
        }

        public static BikeRack WithSingleBike()
        {
            return new BikeRack {_availableBikes = 1};
        }

        private bool IsEmpty()
        {
            return _availableBikes == 0;
        }

        public static BikeRack EmptyWithCapacity(int capacity)
        {
            return new BikeRack {_availableBikes = 0, _maxCapacity = capacity};
        }
    }
}