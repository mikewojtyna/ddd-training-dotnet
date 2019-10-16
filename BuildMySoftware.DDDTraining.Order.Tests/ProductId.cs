using System;

namespace BuildMySoftware.DDDTraining.Order.Tests
{
    public class ProductId
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public override bool Equals(object obj)
        {
            return obj is ProductId id &&
                   Id.Equals(id.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}