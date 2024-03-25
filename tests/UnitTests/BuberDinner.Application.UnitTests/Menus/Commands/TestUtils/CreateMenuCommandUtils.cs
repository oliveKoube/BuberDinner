using BuberDinner.Application.Menus.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    //name
    //description
    //list of sections
    public static CreateMenuCommand CreateCommand(List<CreateMenuSectionCommand>? sections = null)
        => new(
        Constants.Host.Id.ToString()!,
        Constants.Menu.Name,
        Constants.Menu.Description,
        sections ?? CreateSectionsCommands()
    );

    public static List<CreateMenuSectionCommand> CreateSectionsCommands(
        int sectionCount= 1,List<CreateMenuItemCommand>? items = null) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                Constants.Menu.SectionNameFromGivenIndex(index),
                Constants.Menu.SectionDescriptionFromGivenIndex(index),
                items ?? CreateItemsCommands()
            )).ToList();

    public static List<CreateMenuItemCommand> CreateItemsCommands(int itemCount= 1) =>
        Enumerable.Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                Constants.Menu.ItemNameFromGivenIndex(index),
                Constants.Menu.ItemDescriptionFromGivenIndex(index)
            )).ToList();
}
