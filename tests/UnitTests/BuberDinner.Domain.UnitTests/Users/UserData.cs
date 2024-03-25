using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Domain.UnitTests.Users;

internal static class UserData
{
    public static readonly FirstName FirstName = new("John");
    public static readonly LastName LastName = new("Doe");
    public static readonly Email Email = new("test@test.com");
    public static readonly Password Password = new("password123");
}
