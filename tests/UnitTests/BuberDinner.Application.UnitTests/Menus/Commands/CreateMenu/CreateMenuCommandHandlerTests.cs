using Bookify.Domain.Abstractions;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using FluentAssertions;
using NSubstitute;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly IMenuRepository _menuRepositoryMock;
    private readonly IUnitOfWork _unitOfWorkMock;

    public CreateMenuCommandHandlerTests()
    {
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _menuRepositoryMock = Substitute.For<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_menuRepositoryMock,_unitOfWorkMock);
    }

    //T1 : System Under Test - logical component we are testing
    //T2 : Scenario - what we're testing
    //T3 : Expected outcome - what we expect the logical component to do
    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValide_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        //Arrange

        //Act
        ErrorOr<Menu> result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _menuRepositoryMock.Received(1).Add(Arg.Is<Menu>(menu => menu.Id == result.Value.Id));
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
            sections: CreateMenuCommandUtils.CreateSectionsCommands(sectionCount: 3))
        };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommands(sectionCount: 3,
                items: CreateMenuCommandUtils.CreateItemsCommands(itemCount: 3)))
        };
    }
}
