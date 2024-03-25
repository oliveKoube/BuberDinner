using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.Events;

public sealed record MenuCreatedDomainEvent(Menu menu) : IDomainEvent;
