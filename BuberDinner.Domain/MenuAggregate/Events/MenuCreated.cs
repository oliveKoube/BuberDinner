using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.Events;

public record MenuCreated(Menu menu) : IDomainEvent;