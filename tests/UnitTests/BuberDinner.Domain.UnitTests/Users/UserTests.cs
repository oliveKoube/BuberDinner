using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.Events;
using FluentAssertions;

namespace BuberDinner.Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void Create_ValidInput_ReturnsNewUser()
    {
        //Arrange

        //Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email, UserData.Password);

        //Assert
        user.FirstName.Should().Be(UserData.FirstName);
        user.LastName.Should().Be(UserData.LastName);
        user.Email.Should().Be(UserData.Email);
        user.Password.Should().Be(UserData.Password);
    }

    [Fact]
    public void Create_Should_RaiseDomainEvent_WhenNameIsValid()
    {
        // Arrange

        // Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email, UserData.Password);

        // Assert
        user.DomainEvents
            .Should().ContainSingle()
            .Which
            .Should().BeOfType<UserCreatedDomainEvent>();
    }
}
