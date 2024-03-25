using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Common.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, IErrorOr>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
