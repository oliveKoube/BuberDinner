using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
    public override string Value { get; protected set; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(UserId userId) => new($"Host_{userId}");

    public static HostId Create(string value) => new(value);

    public override IEnumerable<object> GetEqualityComponnents()
    {
        yield return Value;
    }
}
