using System;
using System.Collections.Generic;
using System.Text;

namespace BuildMySoftware.DDDTraining.Bike
{
    public class BikeId
    {

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public Guid Id { get; private set; }
        public BikeId(Guid id)
        {
            this.Id = id;
        }
        public BikeId() : this(Guid.NewGuid())
        {
        }

    }
}
