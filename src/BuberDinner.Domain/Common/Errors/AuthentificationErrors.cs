using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static class AuthentificationErrors
{
    public static Error InvalidCreadentials => Error.Validation(code:"Auth.InvalidCred",
        description:"Invalid password.");
}