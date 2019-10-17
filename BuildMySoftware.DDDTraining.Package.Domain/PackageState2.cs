namespace BuildMySoftware.DDDTraining.Package
{
    internal class PackageState2 : PackageState
    {
        public PackageState2(PackageUsingStatePattern package) : base(package)
        {
        }

        public override void Operation()
        {
            _package.HandleMessage("Handling state 2");
            // logic for state 2
            // decide based on domain logic which is the next state in this aggregate after calling this operation
            _package.changeState(State1(_package));
        }
    }
}