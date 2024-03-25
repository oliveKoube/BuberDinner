using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Common.Messaging;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Authentification.Register;

public sealed record RegisterCommand
    (FirstName FirstName, LastName LastName, Email Email,
        Password Password) : ICommand<AuthentificationResult>;
