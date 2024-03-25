using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public record CustomError(string Code, string Name)
{
    public static Error NullValue => Error.Custom(type: (int)ErrorType.Unexpected,
        code:"Error.NullValue",
        description:"Null value was provided");
}
