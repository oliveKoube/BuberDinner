using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuSectionId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

        public static MenuSectionId Create(Guid value) => new(value);
        public override IEnumerable<object> GetEqualityComponnents()
        {
            yield return Value; 
        }
    }
}
