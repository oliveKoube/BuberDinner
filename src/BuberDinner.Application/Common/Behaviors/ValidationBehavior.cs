using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Common;
using ErrorOr;
using FluentResults;
using FluentValidation;
using MediatR;
using Error = ErrorOr.Error;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest,TResponse> 
    : IPipelineBehavior<TRequest,TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator=null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }

        var errorList = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));

        // before the handler
        // var result = await next();
        // after the handler
        return (dynamic)errorList;
    }
}