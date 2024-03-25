using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Register;
using ErrorOr;
using FastEndpoints;
using MediatR;

namespace BuberDinner.Api.Register;

public class RegisterEndpoint : Endpoint<RegisterRequest,RegisterResponse>
{
    private readonly ISender _mediator;
    private readonly MapsterMapper.IMapper _mapper;

    public RegisterEndpoint(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Post("api/v1/register");
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        RegisterCommand command = _mapper.Map<RegisterCommand>(req);
        ErrorOr<AuthentificationResult> authResult = await _mediator.Send(command,ct);

        await authResult.Match(
            result => SendOkAsync(_mapper.Map<RegisterResponse>(result),ct),
            errors => SendErrorsAsync(errors[0].NumericType,ct));
    }
}
