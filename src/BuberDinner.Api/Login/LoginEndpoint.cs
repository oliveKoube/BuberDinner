using BuberDinner.Api.Controllers.Authentification;
using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Login;
using ErrorOr;
using FastEndpoints;
using MediatR;
using IMapper = MapsterMapper.IMapper;

namespace BuberDinner.Api.Login;

public class LoginEndpoint : Endpoint<LoginRequest,LoginResponse>
{
    private readonly ISender _mediator;
    private readonly MapsterMapper.IMapper _mapper;

    public LoginEndpoint(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Post("api/login");
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        LoginQuery query = _mapper.Map<LoginQuery>(req);
        ErrorOr<AuthentificationResult> authResult = await _mediator.Send(query,ct);

        await authResult.Match(
            results => SendOkAsync(_mapper.Map<LoginResponse>(results),ct),
            errors => SendErrorsAsync(errors[0].NumericType,ct));
    }

}
