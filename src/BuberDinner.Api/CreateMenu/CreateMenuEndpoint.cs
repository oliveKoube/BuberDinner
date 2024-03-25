using BuberDinner.Api.Controllers.Menu;
using BuberDinner.Application.Menus.CreateMenu;
using ErrorOr;
using FastEndpoints;
using MediatR;

namespace BuberDinner.Api.CreateMenu;

public class CreateMenuEndpoint : Endpoint<CreateMenuRequest, CreateMenuResponse>
{
    private readonly ISender _mediator;
    private readonly MapsterMapper.IMapper _mapper;

    public CreateMenuEndpoint(ISender mediator, MapsterMapper.IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Post("api/v1/host/{hostId}/menus");
    }

    public override async Task HandleAsync(CreateMenuRequest req, CancellationToken ct)
    {
        CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((req.CreateMenu,req.HostId));
        ErrorOr<Domain.MenuAggregate.Menu> createMenuResult = await _mediator.Send(command,ct);

        await createMenuResult.Match(
            result => SendOkAsync(_mapper.Map<CreateMenuResponse>(result), ct),
            errors => SendErrorsAsync(errors[0].NumericType,ct));
    }
}
