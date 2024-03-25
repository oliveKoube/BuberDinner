namespace BuberDinner.Api.Controllers.Menu;

public record CreateMenuResponse(
    string Name,
    string Description,
    float? AverageRating,
    List<CreateMenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record CreateMenuSectionResponse(
    string Name,
    string Description,
    List<CreateMenuItemResponse> Items);

public record CreateMenuItemResponse(
    string Name,
    string Description);
