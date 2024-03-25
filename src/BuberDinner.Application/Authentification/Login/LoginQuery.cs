using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Common.Messaging;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Authentification.Login;

public sealed record LoginQuery(Email Email, Password Password) :
    IQuery<AuthentificationResult>;
