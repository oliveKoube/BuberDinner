using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
