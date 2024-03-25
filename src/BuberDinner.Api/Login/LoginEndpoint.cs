using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Login;
using ErrorOr;
using FastEndpoints;
using MediatR;
using IMapper = MapsterMapper.IMapper;

namespace BuberDinner.Api.Login;

public class LoginEndpoint(ISender mediator, IMapper mapper)
    : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("api/login");
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        LoginQuery query = mapper.Map<LoginQuery>(req);
        ErrorOr<AuthentificationResult> authResult = await mediator.Send(query,ct);

        await authResult.Match(
            results => SendOkAsync(mapper.Map<LoginResponse>(results),ct),
            errors => SendErrorsAsync(errors[0].NumericType,ct));
    }

}
