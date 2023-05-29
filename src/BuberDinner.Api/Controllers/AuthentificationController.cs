using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Queries.Login;
using BuberDinner.Contracts.Authentification;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthentificationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthentificationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            result => Ok(_mapper.Map<AuthentificationResponse>(result)),
            errors => Problem(errors));
    }

    

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);
        
        return authResult.Match(
            results => Ok(_mapper.Map<AuthentificationResponse>(results)),
            errors => Problem(errors));
    }
}