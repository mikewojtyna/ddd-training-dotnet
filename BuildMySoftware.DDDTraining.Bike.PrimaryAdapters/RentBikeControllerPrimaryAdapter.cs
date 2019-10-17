namespace BuildMySoftware.DDDTraining.Bike
{
    public class RentBikeControllerPrimaryAdapter
    {
        private readonly RentBikePort _port;

        public RentBikeControllerPrimaryAdapter(RentBikePort port)
        {
            _port = port;
        }

        public void Post(RentBikeDto dto)
        {
            // translate to some other commands
            BikeRackId bikeRackId = dto.BikeRackId();
            BikeRack bikeId = dto.BikeId();
            _port.RentBike(bikeRackId, bikeId);
        }
    }

    public class BikeRackId : BikeId
    {
    }

    public class RentBikeDto
    {
        public BikeRackId BikeRackId()
        {
            throw new System.NotImplementedException();
        }

        public BikeRack BikeId()
        {
            throw new System.NotImplementedException();
        }
    }
}