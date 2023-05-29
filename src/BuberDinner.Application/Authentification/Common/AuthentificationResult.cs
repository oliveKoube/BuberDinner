using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Authentification.Common;

public record AuthentificationResult(User User,string Token);