using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestRatingId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GuestRatingId(Guid value)
        {
            Value = value;
        }

        public static GuestRatingId CreateUnique() => new(Guid.NewGuid());
        
        public static GuestRatingId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return Value; 
        }
    }
}
