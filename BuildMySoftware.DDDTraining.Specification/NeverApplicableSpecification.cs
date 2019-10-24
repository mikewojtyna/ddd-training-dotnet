namespace BuildMySoftware.DDDTraining.Specification
{
    public class NeverApplicableSpecification<T> : BaseSpecification<T>
    {
        public override bool applies(T t)
        {
            return false;
        }
    }
}