using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

public sealed class BillsId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private BillsId(Guid value)
    {
        Value = value;
    }

    public static BillsId CreateUnique() => new(Guid.NewGuid());

    public static BillsId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponnents()
    {
        yield return Value;
    }
}
