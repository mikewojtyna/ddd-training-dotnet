namespace BuildMySoftware.DDDTraining.Package
{
    internal abstract class PackageState
    {
        protected readonly PackageUsingStatePattern _package;

        protected PackageState(PackageUsingStatePattern package)
        {
            _package = package;
        }

        public static PackageState State1(PackageUsingStatePattern package)
        {
            return new PackageState1(package);
        }

        public abstract void Operation();

        protected static PackageState State2(PackageUsingStatePattern package)
        {
            return new PackageState2(package);
        }
    }
}