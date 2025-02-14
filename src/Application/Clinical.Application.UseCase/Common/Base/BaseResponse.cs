namespace Clinical.Application.UseCase.Common.Base;

public class BaseResponse<T>
{
    public bool IsSuccess{get;set;}
    public T? Data{get;set;}
    public string? Message{get;set;}
    public IEnumerable<BaseError>? Errors{get;set;}
}