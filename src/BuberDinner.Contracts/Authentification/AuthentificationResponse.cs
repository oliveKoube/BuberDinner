namespace BuberDinner.Contracts.Authentification;

public record AuthentificationResponse(Guid Id, string FirstName, string LastName, string Email, string Token);