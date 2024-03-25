using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique() => new(Guid.NewGuid());

    public static GuestId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponnents()
    {
        yield return Value;
    }
}
