using BuberDinner.Application.Authentification.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentification.Commands.Register;

public record RegisterCommand
    (string FirstName, string LastName, string Email,
        string Password) : IRequest<ErrorOr<AuthentificationResult>>;