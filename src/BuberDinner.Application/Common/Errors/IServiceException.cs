using System.Net;

namespace BuberDinner.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode HttpStatusCode { get; }
    public string ErrorMessage { get; }
}