using FluentResults;

namespace BuberDinner.Application.Common.Errors;

public class DuplicationEmailError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}