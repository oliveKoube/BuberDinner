using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.Events;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId, Guid>
{
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    private User(UserId userId, FirstName firstName, LastName lastName, Email email,
        Password password)
        : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = DateTime.Now;
        UpdatedDateTime = DateTime.Now;
    }

    public static User Create(FirstName firstName, LastName lastName, Email email, Password password)
    {
        var user = new User(UserId.CreateUnique(), firstName, lastName, email, password);

        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id.Value));

        return user;
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}
