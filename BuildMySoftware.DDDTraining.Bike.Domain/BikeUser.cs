namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeUser
    {
        public bool IsBLocked { get; private set; }

        public static BikeUser Blocked()
        {
            return new BikeUser() {IsBLocked = true};
        }
    }
}