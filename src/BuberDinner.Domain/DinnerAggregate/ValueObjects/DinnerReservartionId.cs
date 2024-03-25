using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerReservartionId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private DinnerReservartionId(Guid value)
    {
        Value = value;
    }

    public static DinnerReservartionId CreateUnique() => new(Guid.NewGuid());

    public static DinnerReservartionId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponnents()
    {
        yield return Value;
    }
}
