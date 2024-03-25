using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static class UserErrors
{
    public static Error DuplicateEmail => Error.Conflict(code:"User.DuplicateEmail",
        description:"Email already in use");
}