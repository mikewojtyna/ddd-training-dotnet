namespace BuildMySoftware.DDDTraining.Specification
{
    public interface ISpecification<T>
    {
        bool applies(T t);
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not(ISpecification<T> specification);
    }
}