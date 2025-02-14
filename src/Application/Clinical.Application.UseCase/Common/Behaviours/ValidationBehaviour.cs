using Clinical.Application.UseCase.Common.Base;
using FluentValidation;
using MediatR;
using ValidationException = Clinical.Application.UseCase.Common.Exceptions.ValidationException;

namespace Clinical.Application.UseCase.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .Select(x => new BaseError
                {
                    PropertyName = x.PropertyName,
                    ErrorMessage = x.ErrorMessage
                }).ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}