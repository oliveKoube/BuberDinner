namespace BuberDinner.Contracts.Authentification;

public record RegisterRequest(string FirstName,string LastName,string Email,string Password);