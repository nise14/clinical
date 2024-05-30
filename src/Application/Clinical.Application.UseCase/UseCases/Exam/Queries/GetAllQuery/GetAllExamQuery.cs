using Clinical.Application.Dtos.Exam.Response;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Queries.GetAllQuery;

public class GetAllExamQuery:IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
{
    
}