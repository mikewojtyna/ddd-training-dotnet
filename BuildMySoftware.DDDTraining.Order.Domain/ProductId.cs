namespace BuildMySoftware.DDDTraining.Order
{
    public class ProductId
    {
        private string Id { get; }

        public ProductId(string id)
        {
            Id = id;
        }

        protected bool Equals(ProductId other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductId) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}