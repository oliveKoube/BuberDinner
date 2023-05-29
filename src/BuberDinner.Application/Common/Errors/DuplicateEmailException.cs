using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailException : Exception,IServiceException
{
    public HttpStatusCode HttpStatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exist";
}