using Clinical.Application.Dtos.Exam.Response;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery;

public class GetExamByIdQuery : IRequest<BaseResponse<GetExamByIdResponseDto>>
{
    public int ExamId { get; set; }
}