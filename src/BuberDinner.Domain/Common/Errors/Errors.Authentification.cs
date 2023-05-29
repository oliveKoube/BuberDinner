using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentification
    {
        public static Error InvalidCreadentials => Error.Validation(code:"Auth.InvalidCred",
            description:"Invalid password.");
    }
}