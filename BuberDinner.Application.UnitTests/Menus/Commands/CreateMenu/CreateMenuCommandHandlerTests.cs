using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;

using FluentAssertions;

using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
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
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
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