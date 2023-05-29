using BuberDinner.Application.Authentification.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentification.Queries.Login;

public record LoginQuery(string Email, string Password) : 
    IRequest<ErrorOr<AuthentificationResult>>;
