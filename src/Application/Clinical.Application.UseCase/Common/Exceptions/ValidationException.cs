using Clinical.Application.UseCase.Common.Base;

namespace Clinical.Application.UseCase.Common.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<BaseError>? Errors { get; }

    public ValidationException() : base()
    {
        Errors = new List<BaseError>();
    }

    public ValidationException(IEnumerable<BaseError>? errors) : this()
    {
        Errors = errors;
    }
}