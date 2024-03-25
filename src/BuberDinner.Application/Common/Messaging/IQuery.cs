using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Common.Messaging;

public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
{
}
