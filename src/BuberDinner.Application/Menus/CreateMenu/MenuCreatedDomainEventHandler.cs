using BuberDinner.Domain.MenuAggregate.Events;
using MediatR;

namespace BuberDinner.Application.Menus.CreateMenu;

public class MenuCreatedDomainEventHandler : INotificationHandler<MenuCreatedDomainEvent>
{
    public Task Handle(MenuCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
