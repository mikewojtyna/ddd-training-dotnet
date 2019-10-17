namespace BuildMySoftware.DDDTraining.Package
{
    internal class PackageState1 : PackageState
    {
        public PackageState1(PackageUsingStatePattern package) : base(package)
        {
        }

        public override void Operation()
        {
            _package.HandleMessage("Handling state 1");
            // logic for state 1
            // decide based on domain logic which is the next state in this aggregate after calling this operation
            _package.changeState(State2(_package));
        }
    }
}