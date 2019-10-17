namespace BuildMySoftware.DDDTraining.Package
{
    public class PackageUsingStatePattern
    {
        private PackageState _state;
        private readonly MessageCollector _messageCollector;

        public PackageUsingStatePattern(MessageCollector messageCollector)
        {
            _messageCollector = messageCollector;
            _state = PackageState.State1(this);
        }

        public void Operation()
        {
            _state.Operation();
        }

        internal void HandleMessage(string msg)
        {
            _messageCollector(msg);
        }

        internal void changeState(PackageState state)
        {
            _state = state;
        }
    }
}