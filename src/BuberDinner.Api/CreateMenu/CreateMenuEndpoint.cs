using BuberDinner.Api.Controllers.Menu;
using BuberDinner.Application.Menus.CreateMenu;
using ErrorOr;
using FastEndpoints;
using MediatR;
using IMapper = MapsterMapper.IMapper;

namespace BuberDinner.Api.CreateMenu;

public class CreateMenuEndpoint(ISender mediator, IMapper mapper)
    : Endpoint<CreateMenuRequest, CreateMenuResponse>
{
    public override void Configure()
    {
        Post("api/v1/host/{hostId}/menus");
    }

    public override async Task HandleAsync(CreateMenuRequest req, CancellationToken ct)
    {
        CreateMenuCommand command = mapper.Map<CreateMenuCommand>((req.CreateMenu,req.HostId));
        ErrorOr<Domain.MenuAggregate.Menu> createMenuResult = await mediator.Send(command,ct);

        await createMenuResult.Match(
            result => SendOkAsync(mapper.Map<CreateMenuResponse>(result), ct),
            errors => SendErrorsAsync(errors[0].NumericType,ct));
    }
}
