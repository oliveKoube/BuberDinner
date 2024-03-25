using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Common.Messaging;

public interface ICommand : IRequest<IErrorOr>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<ErrorOr<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}
