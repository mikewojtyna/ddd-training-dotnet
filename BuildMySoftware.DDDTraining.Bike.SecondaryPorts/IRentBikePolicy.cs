namespace BuildMySoftware.DDDTraining.Bike
{
    public interface IRentBikePolicy
    {
        bool CanClientRentBike(Client client);
    }
}