using System;

namespace BuildMySoftware.DDDTraining.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public abstract bool applies(T t);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        private class AndSpecification<T> : BaseSpecification<T>
        {
            private readonly ISpecification<T> _left;
            private readonly ISpecification<T> _right;

            public AndSpecification(ISpecification<T> left, ISpecification<T> right)
            {
                _left = left;
                _right = right;
            }

            public override bool applies(T t)
            {
                return _left.applies(t) && _right.applies(t);
            }
        }
    }
}