using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers.Menu;

public class CreateMenuRequest
{
    [FromRoute(Name = "hostId")]
    public string HostId { get; init; }
    public CreateMenu CreateMenu { get; init; }
}
public record CreateMenu(
    string Name,
    string Description,
    List<CreateMenuSection> Sections);

public record CreateMenuSection(
    string Name,
    string Description,
    List<CreateMenuItem> Items);

public record CreateMenuItem(
    string Name,
    string Description);
