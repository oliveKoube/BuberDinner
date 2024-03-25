using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Register;
using ErrorOr;
using FastEndpoints;
using MediatR;
using IMapper = MapsterMapper.IMapper;

namespace BuberDinner.Api.Register;

public class RegisterEndpoint(ISender mediator, IMapper mapper)
    : Endpoint<RegisterRequest, RegisterResponse>
{
    public override void Configure()
    {
        Post("api/v1/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        RegisterCommand command = mapper.Map<RegisterCommand>(req);
        ErrorOr<AuthentificationResult> authResult = await mediator.Send(command,ct);

        await authResult.Match(
            result => SendOkAsync(mapper.Map<RegisterResponse>(result),ct),
            errors => SendErrorsAsync(errors[0].NumericType,ct));
    }
}
