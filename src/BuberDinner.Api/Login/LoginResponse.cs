namespace BuberDinner.Api.Login;

public record LoginResponse(Guid Id, string FirstName, string LastName, string Email, string Token);
