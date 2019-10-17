namespace BuildMySoftware.DDDTraining.Bike
{
    public class RentBikePort
    {
        public void RentBike(BikeId bikeId, BikeRack bikeRack)
        {
            // 1. Load bike rack aggregate by id
            // 2. apply command (rent)
            // 3. save
            // 4. publish events
        }
    }
}