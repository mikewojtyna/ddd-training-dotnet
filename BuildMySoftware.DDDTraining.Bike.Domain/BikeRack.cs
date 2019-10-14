namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeRack
    {
        public BikeRack(int availableBikes)
        {
            AvailableBikes = availableBikes;
        }

        /// <summary>
        /// Rents a bike from this rack.
        /// </summary>
        /// <param name="bikeId">id of the bike to rent</param>
        /// <param name="client">a client who wants to rent a bike</param>
        /// <returns>emitted event</returns>
        /// <exception cref="BikeRentFailedException">thrown when rent fails</exception>
        public BikeRent Rent(BikeId bikeId, Client client)
        {
            if(client.HasNoFunds())
                throw new BikeRentFailedException("Client has no funds");
            if(AvailableBikes == 0)
                throw new BikeRentFailedException("Bike rent failed");
            AvailableBikes--;
            return new BikeRent();
        }

        private int AvailableBikes { get; set; }
    }
}