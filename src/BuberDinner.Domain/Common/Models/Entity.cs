namespace BuberDinner.Domain.Common.Models;

#pragma warning disable S4035
public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
#pragma warning restore S4035
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TId Id { get; protected set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);

#pragma warning disable SA1201
    public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
#pragma warning restore SA1201

    public static bool operator !=(Entity<TId> left, Entity<TId> right) => !Equals(left, right);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Entity<TId>? other) => Equals((object?)other);

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

#pragma warning disable CS8618
    protected Entity()
    {
    }
#pragma warning restore CS8618
}
